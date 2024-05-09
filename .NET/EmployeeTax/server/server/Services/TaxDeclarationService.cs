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


        //TAX FORM SUBMISSION
        public async Task createTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = false;
            taxDeclaration.status = "drafted";
            taxDeclaration.dateOfDeclaration = DateOnly.FromDateTime(DateTime.UtcNow).ToString("yyyy-MM-dd");
            _db.TaxDeclarations.Add(taxDeclaration);
            await _db.SaveChangesAsync();
        }


        //UPDATE TAX FORM
        public async Task updateTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = true;
            taxDeclaration.status = "submitted";
            _db.TaxDeclarations.Update(taxDeclaration);
            await _db.SaveChangesAsync();
        }


        //CHANGE REQUEST TO UNFREEZE  TAX FORM
        public async Task<bool> changeRequest(ChangeRequest newChangeRequest)
        {
           // newChangeRequest.dateOfSubmission = DateOnly.FromDateTime(DateTime.UtcNow).ToString("yyyy-MM-dd");
            _db.ChangeRequests.Add(newChangeRequest);
            await _db.SaveChangesAsync();
            return true;
        }



        //DELETE  CHNAGE REQUEST --after unfreezing it 

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
            await _db.SaveChangesAsync();
        }

        //REJECT TAX DECLARATION FORM
        public async Task rejectTaxForm(TaxDeclaration taxForm)
        {
            taxForm.status = "rejected";
            await _db.SaveChangesAsync();
        }
    }
}


