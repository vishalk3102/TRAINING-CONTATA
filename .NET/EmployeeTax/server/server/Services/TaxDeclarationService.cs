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
        public async Task<List<TaxDeclaration>> getAllTaxDeclarations()
        {
            var taxDeclarations = await _db.TaxDeclarations.ToListAsync();
            return taxDeclarations;
        }


        //GET TAX DECLARATION BY TAXID
        public async Task<TaxDeclaration>  getTaxDeclaration(int taxId)
        {
            var taxDeclaration = await _db.TaxDeclarations.FindAsync(taxId);
            return taxDeclaration;
        }


        //GET MY TAX DECLARATION SUBMISSIONS
        public async Task<IEnumerable<TaxDeclaration>> getMyTaxDeclaration(int empId)
        {

            var taxDeclarations = await _db.TaxDeclarations.Where(td => td.empId == empId).ToListAsync(); 
            return taxDeclarations;
        }


        //GET ALL TAX DECLARATION WITH CHANGE REQUEST
        public async Task<List<ChangeRequest>> getChangeRequestTaxDeclaration()
        {
            var changeRequests = await _db.ChangeRequests.ToListAsync();
            return changeRequests;
        }


        //TAX FORM SUBMISSION
        public async Task createTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = true;
            taxDeclaration.dateOfDeclaration = DateOnly.FromDateTime(DateTime.UtcNow).ToString("yyyy-MM-dd");
            _db.TaxDeclarations.Add(taxDeclaration);
            await _db.SaveChangesAsync();
        }


        //UPDATE TAX FORM
        public async Task updateTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = true;
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
    }
}


