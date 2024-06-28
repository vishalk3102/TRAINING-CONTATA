using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using TaxManagementNew.Data;
using TaxManagementNew.Models;
using TaxManagementNew.Models.ViewModel;

namespace TaxManagementNew.Controllers
{
    public class AdminController:Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUser() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUser();
            ViewBag.EmpId = user.EmpId;
            ViewBag.Name = user.Name; 
            ViewBag.DateOfBirth = user.DateOfBirth; 
            ViewBag.Age = user.Age; 
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.PanNo = user.PanNo;
            ViewBag.Address = user.Address;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TaxDeclaration(int? FinancialYear, string Name, int? EmpId)
        {
            try
            {
                var query = from td in _db.TaxDeclarations
                            join u in _db.Users on td.EmpId equals u.EmpId
                            join cr in _db.ChangeRequests on td.TaxId equals cr.TaxId into crGroup
                            from cr in crGroup.DefaultIfEmpty()
                            select new TaxDeclarationViewModel
                            {
                                EmpId = td.EmpId,
                                Name = u.Name,
                                FinancialYear=td.FinancialYear,
                                DateOfSubmission = td.DateOfDeclaration,
                                Status = td.Status,
                                Reason = cr != null ? cr.Reason : "",
                                TaxId = td.TaxId
                            };

                if (FinancialYear.HasValue)
                {
                    query = query.Where(x => x.FinancialYear == FinancialYear.Value);
                }

                if (!string.IsNullOrEmpty(Name))
                {
                    query = query.Where(x => x.Name.Contains(Name));
                }

                if (EmpId.HasValue)
                {
                    query = query.Where(x => x.EmpId == EmpId.Value);
                }

                var model = await query.ToListAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Submission(int? FinancialYear, string Name, int? EmpId, string Status)
        {

            try
            {
                var query = from td in _db.TaxDeclarations
                            join u in _db.Users on td.EmpId equals u.EmpId
                            where td.Status == "submitted" || td.Status == "accepted" || td.Status == "rejected"
                            select new TaxDeclarationViewModel
                            {
                                EmpId = td.EmpId,
                                Name = u.Name,
                                FinancialYear = td.FinancialYear,
                                Status = td.Status,
                                DateOfSubmission = td.DateOfDeclaration,
                                TaxId = td.TaxId
                            };
                if (FinancialYear.HasValue)
                {
                    query = query.Where(x => x.FinancialYear == FinancialYear.Value);
                }

                if (!string.IsNullOrEmpty(Name))
                {
                    query = query.Where(x => x.Name.Contains(Name));
                }

                if (EmpId.HasValue)
                {
                    query = query.Where(x => x.EmpId == EmpId.Value);
                }

                if (!string.IsNullOrEmpty(Status))
                {
                    query = query.Where(x => x.Status.ToLower() == Status.ToLower());
                }
                var model = await query.ToListAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }



        public async Task deleteChangeRequest(int TaxId)
        {
            var changeRequest = await _db.ChangeRequests.FirstOrDefaultAsync(td => td.TaxId == TaxId);

            if (changeRequest != null)
            {
                _db.ChangeRequests.Remove(changeRequest);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<IActionResult> UnfreezeForm(int TaxId)
        {
            var taxForm = await _db.TaxDeclarations.FindAsync(TaxId);

            if(taxForm == null)
            {
                return NotFound();  
            }

            taxForm.isFrozen = false;
            await deleteChangeRequest(TaxId);
            await _db.SaveChangesAsync();
            return RedirectToAction("TaxDeclaration");

        }


        [HttpPost]
        public async Task<IActionResult> AcceptForm(int TaxId)
        {
            var taxForm = await _db.TaxDeclarations.FindAsync(TaxId);

            if(taxForm == null)
            {
                return NotFound();  
            }

            taxForm.Status = "accepted";
            taxForm.isSubmitted = false;
            taxForm.isAccepted = true;
            taxForm.isDrafted = false;
            taxForm.isRejected = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("TaxDeclaration");

        } 
        
        public async Task<IActionResult> RejectForm(int TaxId)
        {
            var taxForm = await _db.TaxDeclarations.FindAsync(TaxId);

            if(taxForm == null)
            {
                return NotFound();  
            }

            taxForm.Status = "rejected";
            taxForm.isSubmitted = false;
            taxForm.isRejected = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("TaxDeclaration");

        }
    }
}
