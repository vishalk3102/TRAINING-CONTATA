using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TaxManagementNew.Data;
using TaxManagementNew.Models;

namespace TaxManagementNew.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


       // [Authorize(Roles ="client")]
        public  IActionResult TaxForm()
        {
            return View();
        }

        //[Authorize(Roles = "client")]
        [HttpGet]
        public async Task<IActionResult> ShowTaxForm(string FinancialYear)
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                var userId=user.Id;
                var EmpId=user.EmpId;

                // Parse financialYear to int
                if (!int.TryParse(FinancialYear, out int financialYearInt))
                {
                    return BadRequest("Invalid Financial Year");
                }


                ViewBag.FinancialYear = FinancialYear;
                ViewBag.EmpId = EmpId;
                ViewBag.Name = user.Name;
                ViewBag.PanNo = user.PanNo;
                ViewBag.Address = user.Address;
                ViewBag.Email = user.Email;
                ViewBag.Phone = user.PhoneNumber;

                TaxDeclaration taxDeclaration = await GetTaxByFinancialYearAndEmpId(financialYearInt, EmpId);
                
                if(taxDeclaration!=null)
                {
                    // If the form is already submitted and frozen
                 /*   if (taxDeclaration.isFrozen)
                    {
                        return RedirectToAction("FreezedDisplay", new { id = taxDeclaration.taxId });
                    } */
                    // If the form is saved as draft
                  //  if (taxDeclaration.isDrafted)
                   /* {
                        return RedirectToAction("UpdateForm", new { id = taxDeclaration.taxId });
                    }
                    */
                    // If the form exists but is not frozen or drafted
                    return View(taxDeclaration);
                }

                return View(new TaxDeclaration
                {
                    EmpId = EmpId,
                    FinancialYear = financialYearInt,
                    DateOfDeclaration = DateTime.Now.ToString("yyyy-MM-dd"),
                    Status = "pending",
                    isSubmitted = false,
                    isDrafted = false,
                    isAccepted = false,
                    isRejected = false,
                    isFrozen = false
                });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
        }


        //[Authorize(Roles = "client")]
        [HttpPost]
        public async Task<IActionResult> ProcessTaxForm(TaxDeclaration taxDeclaration, string action, string FinancialYear)
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                var userId = user.Id;
                var empId = user.EmpId;

                // Parse financialYear to int
                if (!int.TryParse(FinancialYear, out int financialYearInt))
                {
                    return BadRequest("Invalid Financial Year");
                }

                taxDeclaration.FinancialYear = financialYearInt;
                var existingTax = await GetTaxByFinancialYearAndEmpId(financialYearInt, empId);

                if (existingTax != null)
                {
                    taxDeclaration.TaxId = existingTax.TaxId;
                }

                switch (action.ToLower())
                {
                    case "save":
                        await SaveTaxDeclaration(taxDeclaration);
                        TempData["Message"] = "Form saved successfully";
                        return RedirectToAction("ShowTaxForm", new { FinancialYear = taxDeclaration.FinancialYear });

                    case "submit":
                        await SubmitTaxDeclaration(taxDeclaration);
                        TempData["Message"] = "Form submitted successfully";
                        return RedirectToAction("ShowTaxForm", new { FinancialYear = taxDeclaration.FinancialYear });

                    default:
                        return BadRequest("Invalid action");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
        }

        private async Task SaveTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = false;
            taxDeclaration.Status = "drafted";
            taxDeclaration.isSubmitted = false;
            taxDeclaration.isDrafted = true;
            taxDeclaration.DateOfDeclaration = DateTime.Now.ToString("yyyy-MM-dd");

            if (taxDeclaration.TaxId == 0)
            {
                _db.TaxDeclarations.Add(taxDeclaration);
            }
            else
            {
                _db.TaxDeclarations.Update(taxDeclaration);
            }

            await _db.SaveChangesAsync();
        }

        private async Task SubmitTaxDeclaration(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = true;
            taxDeclaration.Status = "submitted";
            taxDeclaration.isSubmitted = true;
            taxDeclaration.isDrafted = false;
            taxDeclaration.DateOfDeclaration = DateTime.Now.ToString("yyyy-MM-dd");

            if (taxDeclaration.TaxId == 0)
            {
                _db.TaxDeclarations.Add(taxDeclaration);
            }
            else
            {
                _db.TaxDeclarations.Update(taxDeclaration);
            }

            await _db.SaveChangesAsync();
        }


        private Task<ApplicationUser> GetCurrentUser() => _userManager.GetUserAsync(HttpContext.User);

        private async Task<TaxDeclaration> GetTaxByFinancialYearAndEmpId(int financialYear, int empId)
        {
            var taxDeclaration = await _db.TaxDeclarations.FirstOrDefaultAsync(td => td.FinancialYear == financialYear && td.EmpId == empId);
            return taxDeclaration;
        }
    }
}
