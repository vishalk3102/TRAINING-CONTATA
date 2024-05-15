using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Model;
using System.Xml.Linq;


namespace server.Services
{
    public class TaxDeclarationService
    {
        private readonly EmployeeTaxDbContext _db;

        public TaxDeclarationService(EmployeeTaxDbContext db)
        {
            _db = db;
        }


        //GET  ALL TAX DECLARATION SUBMISSIONS
        public async Task<List<(TaxDeclaration,Employee)>> getAllTaxDeclarations()
        {
            var query = from taxDeclaration in _db.TaxDeclarations
                        join employee in _db.Employees
                        on taxDeclaration.empId equals employee.empId
                        select new
                        {
                            TaxDeclarationDetails = taxDeclaration,
                            EmployeeDetails = employee
                        };
            var result = await query.ToListAsync();
            var taxDeclarationsResult=result.Select(item=>(item.TaxDeclarationDetails, item.EmployeeDetails)).ToList();
            return taxDeclarationsResult;
        }


        //GET TAX DECLARATION BY TAXID
        public async Task<List<(TaxDeclaration, Employee)>> getTaxDeclaration(int taxId)
        {
            var query = from taxDeclaration in _db.TaxDeclarations
                        where taxDeclaration.taxId == taxId
                        join employee in _db.Employees
                        on taxDeclaration.empId equals employee.empId
                        select new
                        {
                            TaxDeclarationDetails = taxDeclaration,
                            EmployeeDetails = employee
                        };

            var result = await query.ToListAsync();
            var taxDeclarationsresult = result.Select(item => (item.TaxDeclarationDetails, item.EmployeeDetails)).ToList();
            return taxDeclarationsresult;
        }

        //GET TAX DECLARATION BY FINANCIAL YEAR AND EMPID
        public async Task<TaxDeclaration>  getTaxByFinancialYearAndEmpId(int financialYear,int empId)
        {
            var taxDeclaration = await _db.TaxDeclarations.FirstOrDefaultAsync(td => td.financialYear == financialYear && td.empId==empId);
            return taxDeclaration;
        }


        //GET MY TAX DECLARATION SUBMISSIONS
        public async Task<IEnumerable<TaxDeclaration>> getMyTaxDeclaration(int empId)
        {

            var taxDeclarations = await _db.TaxDeclarations.Where(td => td.empId == empId).ToListAsync(); 
            return taxDeclarations;
        }


        //GET ALL TAX DECLARATION WITH CHANGE REQUEST
        public async Task<List<Tuple<string, TaxDeclaration, Employee>>> getChangeRequestTaxDeclaration()
        {

            var query = from changeRequest in _db.ChangeRequests
                        join taxDeclaration in _db.TaxDeclarations
                        on changeRequest.taxId equals taxDeclaration.taxId
                        join employee in _db.Employees
                        on taxDeclaration.empId equals employee.empId
                        select new
                        {
                            ChangeRequestDetails = changeRequest.reason,
                            TaxDeclarationDetails = taxDeclaration,
                            EmployeeDetails = employee
                        };
            var result = await query.ToListAsync();
            var requestResult = result.Select(item =>Tuple.Create(item.ChangeRequestDetails, item.TaxDeclarationDetails, item.EmployeeDetails)).ToList();
            return requestResult;
           
        }


        //SUBMIT TAX FORM 
        public async Task submitTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = true;
            taxDeclaration.status= "submitted";
            taxDeclaration.isSubmitted = true;
            _db.TaxDeclarations.Add(taxDeclaration);
            await _db.SaveChangesAsync();
        }

        //SAVE TAX FORM SUBMISSION 
        public async Task saveTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = false;
            taxDeclaration.status = "drafted";
            taxDeclaration.isSubmitted = false;
            taxDeclaration.isDrafted = true;
            _db.TaxDeclarations.Add(taxDeclaration);
            await _db.SaveChangesAsync();
        }

        //UPDATE TAX FORM
        public async Task updateTaxDeclaration(TaxDeclaration taxDeclaration,bool isSubmitted)
        {
            var existingTax = await _db.TaxDeclarations.FindAsync(taxDeclaration.taxId);
            if(existingTax!=null)
            {
                existingTax.anyOtherIncome=taxDeclaration.anyOtherIncome;
                existingTax.sukanyaSamriddhiAccount=taxDeclaration.sukanyaSamriddhiAccount;
                existingTax.PPF=taxDeclaration.PPF;
                existingTax.lifeInsurancePremium=taxDeclaration.lifeInsurancePremium;
                existingTax.tuitionFee=taxDeclaration.tuitionFee;
                existingTax.bankFixedDeposit=taxDeclaration.bankFixedDeposit;
                existingTax.principalHousingLoan=taxDeclaration.principalHousingLoan;
                existingTax.NPS=taxDeclaration.NPS;
                existingTax.higherEducationLoanInterest=taxDeclaration.higherEducationLoanInterest;
                existingTax.houseRent=taxDeclaration.houseRent;
                existingTax.TDS=taxDeclaration.TDS;
                existingTax.mediClaim=taxDeclaration.mediClaim;
                existingTax.preventiveHealthCheckUp=taxDeclaration.preventiveHealthCheckUp;
                existingTax.LTA=taxDeclaration.LTA;
                existingTax.dateOfDeclaration=taxDeclaration.dateOfDeclaration;

                if (isSubmitted)
                {
                    if(existingTax.isRejected==true)
                    {
                        existingTax.status = "rejected";
                        existingTax.isFrozen = true;
                        existingTax.isRejected = true;
                        existingTax.isSubmitted=true;
                        existingTax.isDrafted=false;
                    }
                    else
                    {
                        existingTax.isFrozen = true;
                        existingTax.status = "submitted";
                        existingTax.isSubmitted = true;
                        existingTax.isDrafted = false;
                    }
                }
                else
                {
                    if (existingTax.isRejected == true)
                    {
                        existingTax.status = "rejected";
                        existingTax.isFrozen = false;
                        existingTax.isRejected = true;
                        existingTax.isSubmitted = false;
                        existingTax.isDrafted = true;
                    }
                    else
                    {
                        existingTax.isFrozen = false;
                        existingTax.status = "drafted";
                        existingTax.isSubmitted = false;
                        existingTax.isDrafted = true;
                    }
                }
            }
            _db.TaxDeclarations.Update(existingTax);
            await _db.SaveChangesAsync();
        }


        //DELETE  TAX DECLARATION 
        public async Task deleteTaxDeclaration(int taxId)
        {
            var taxDeclaration = await _db.TaxDeclarations.FindAsync(taxId);
            if (taxDeclaration != null)
            {
                _db.TaxDeclarations.Remove(taxDeclaration);
                await _db.SaveChangesAsync();
            }
        }

        //CHANGE REQUEST TO UNFREEZE  TAX FORM
        public async Task<bool> changeRequest(ChangeRequest newChangeRequest)
        {
            _db.ChangeRequests.Add(newChangeRequest);
            await _db.SaveChangesAsync();
            return true;
        }



        //DELETE  CHANGE REQUEST --after unfreezing it 

        public async Task deleteChangeRequest(int taxId)
        {
            var changeRequest = await _db.ChangeRequests.FirstOrDefaultAsync(td=>td.taxId==taxId);

            if (changeRequest != null)
            {
                _db.ChangeRequests.Remove(changeRequest);
                await _db.SaveChangesAsync();
            }
        }

        //UNFREEZE TAX DECLARATION FORM
        public async Task unfreezeTaxForm(TaxDeclaration taxForm)
        {
            taxForm.isFrozen=false;
            await _db.SaveChangesAsync();
        }

        //ACCEPT TAX DECLARATION FORM
        public async Task acceptTaxForm(TaxDeclaration taxForm)
        {
            taxForm.status = "accepted";
            taxForm.isSubmitted = false;
            taxForm.isAccepted = true;
            taxForm.isDrafted = false;
            taxForm.isRejected = false;
            await _db.SaveChangesAsync();
        }

        //REJECT TAX DECLARATION FORM
        public async Task rejectTaxForm(TaxDeclaration taxForm)
        {
            taxForm.status = "rejected";
            taxForm.isSubmitted = false;
            taxForm.isRejected = true;
            await _db.SaveChangesAsync();
        }
    }
}


