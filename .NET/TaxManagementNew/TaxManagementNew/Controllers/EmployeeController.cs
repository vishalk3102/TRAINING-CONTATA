using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TaxManagementNew.Data;
using TaxManagementNew.Models;
using TaxManagementNew.Models.ViewModel;

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

        [Authorize(Roles = "client")]
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

        [Authorize(Roles ="client")]
        public  IActionResult TaxForm()
        {
            return View();
        }

        [Authorize(Roles = "client")]
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
                     ViewBag.Status = taxDeclaration.Status;
                     ViewBag.isSubmitted= taxDeclaration.isSubmitted;
                     ViewBag.isDrafted = taxDeclaration.isDrafted;
                     ViewBag.isAccepted = taxDeclaration.isAccepted;
                     ViewBag.isRejected = taxDeclaration.isRejected;
                     ViewBag.isFrozen = taxDeclaration.isFrozen;
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


        [Authorize(Roles = "client")]
        [HttpPost]
        public async Task<IActionResult> ProcessTaxForm(TaxDeclaration taxDeclaration, string action, int  FinancialYear)
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                var userId = user.Id;
                var empId = user.EmpId;


                var existingTax = await GetTaxByFinancialYearAndEmpId(FinancialYear, empId);

                if (existingTax != null)
                {
                    taxDeclaration.TaxId = existingTax.TaxId;
                }

                switch (action.ToLower())
                {
                    case "save":
                        await SaveTaxForm(taxDeclaration);
                        TempData["Message"] = "Form saved successfully";
                        return RedirectToAction("ShowTaxForm", new { FinancialYear = taxDeclaration.FinancialYear });

                    case "submit":
                        if (await SubmitTaxForm(taxDeclaration))
                        {
                            TempData["Message"] = "Form submitted successfully";
                            return RedirectToAction("PreviousSubmissions");
                        }
                        else
                        {
                            return RedirectToAction("ShowTaxForm", new { FinancialYear = taxDeclaration.FinancialYear });
                        }

                    default:
                        return BadRequest("Invalid action");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "client")]
        private async Task SaveTaxForm(TaxDeclaration taxDeclaration)
        {
            taxDeclaration.isFrozen = false;
            taxDeclaration.Status = "drafted";
            taxDeclaration.isSubmitted = false;
            taxDeclaration.isDrafted = true;
            taxDeclaration.DateOfDeclaration = DateTime.Now.ToString("yyyy-MM-dd");

            var existingTaxForm = await _db.TaxDeclarations.FindAsync(taxDeclaration.TaxId);

            if (existingTaxForm != null)
            {
                if (existingTaxForm.isRejected == true)
                {
                    existingTaxForm.Status = "rejected";
                    existingTaxForm.isFrozen = false;
                    existingTaxForm.isRejected = true;
                    existingTaxForm.isSubmitted = false;
                    existingTaxForm.isDrafted = true;
                }
                else
                {
                    existingTaxForm.isFrozen = false;
                    existingTaxForm.Status = "drafted";
                    existingTaxForm.isSubmitted = false;
                    existingTaxForm.isDrafted = true;
                }
                existingTaxForm.AnyOtherIncome = taxDeclaration.AnyOtherIncome;
                existingTaxForm.SukanyaSamriddhiAccount = taxDeclaration.SukanyaSamriddhiAccount;
                existingTaxForm.PPF = taxDeclaration.PPF;
                existingTaxForm.LifeInsurancePremium = taxDeclaration.LifeInsurancePremium;
                existingTaxForm.TuitionFee = taxDeclaration.TuitionFee;
                existingTaxForm.BankFixedDeposit = taxDeclaration.BankFixedDeposit;
                existingTaxForm.PrincipalHousingLoan = taxDeclaration.PrincipalHousingLoan;
                existingTaxForm.NPS = taxDeclaration.NPS;
                existingTaxForm.HigherEducationLoanInterest = taxDeclaration.HigherEducationLoanInterest;
                existingTaxForm.HouseRent = taxDeclaration.HouseRent;
                existingTaxForm.TDS = taxDeclaration.TDS;
                existingTaxForm.MediClaim = taxDeclaration.MediClaim;
                existingTaxForm.PreventiveHealthCheckUp = taxDeclaration.PreventiveHealthCheckUp;
                existingTaxForm.LTA = taxDeclaration.LTA;
                existingTaxForm.DateOfDeclaration = taxDeclaration.DateOfDeclaration;
            }
            else
            {
                // If no existing record is found, add a new one
                _db.TaxDeclarations.Add(taxDeclaration);
            }

            await _db.SaveChangesAsync();
        }

        [Authorize(Roles = "client")]
        private async Task<bool> SubmitTaxForm(TaxDeclaration taxDeclaration)
        {
            var existingDeclaration = await _db.TaxDeclarations.FirstOrDefaultAsync(td => td.EmpId == taxDeclaration.EmpId &&
                                  td.FinancialYear == taxDeclaration.FinancialYear &&
                                  td.isSubmitted);
            if (existingDeclaration != null)
            {
                TempData["ErrorMessage"] = "A tax declaration for this financial year has already been submitted.";
                return false;
            }

            taxDeclaration.isFrozen = true;
            taxDeclaration.Status = "submitted";
            taxDeclaration.isSubmitted = true;
            taxDeclaration.isDrafted = false;
            taxDeclaration.DateOfDeclaration = DateTime.Now.ToString("yyyy-MM-dd");

            var existingTaxForm = await _db.TaxDeclarations.FindAsync(taxDeclaration.TaxId);

            if (existingTaxForm != null)
            {
                if (existingTaxForm.isRejected == true)
                {
                    existingTaxForm.Status = "submitted";
                    existingTaxForm.isFrozen = true;
                    existingTaxForm.isRejected = false;
                    existingTaxForm.isSubmitted = true;
                    existingTaxForm.isDrafted = false;
                }
                else
                {
                    existingTaxForm.isFrozen = true;
                    existingTaxForm.Status = "submitted";
                    existingTaxForm.isSubmitted = true;
                    existingTaxForm.isDrafted = false;
                }
                existingTaxForm.AnyOtherIncome = taxDeclaration.AnyOtherIncome;
                existingTaxForm.SukanyaSamriddhiAccount = taxDeclaration.SukanyaSamriddhiAccount;
                existingTaxForm.PPF = taxDeclaration.PPF;
                existingTaxForm.LifeInsurancePremium = taxDeclaration.LifeInsurancePremium;
                existingTaxForm.TuitionFee = taxDeclaration.TuitionFee;
                existingTaxForm.BankFixedDeposit = taxDeclaration.BankFixedDeposit;
                existingTaxForm.PrincipalHousingLoan = taxDeclaration.PrincipalHousingLoan;
                existingTaxForm.NPS = taxDeclaration.NPS;
                existingTaxForm.HigherEducationLoanInterest = taxDeclaration.HigherEducationLoanInterest;
                existingTaxForm.HouseRent = taxDeclaration.HouseRent;
                existingTaxForm.TDS = taxDeclaration.TDS;
                existingTaxForm.MediClaim = taxDeclaration.MediClaim;
                existingTaxForm.PreventiveHealthCheckUp = taxDeclaration.PreventiveHealthCheckUp;
                existingTaxForm.LTA = taxDeclaration.LTA;
                existingTaxForm.DateOfDeclaration = taxDeclaration.DateOfDeclaration;
            }
            else
            {
                // If no existing record is found, add a new one
                _db.TaxDeclarations.Add(taxDeclaration);
            }

            await _db.SaveChangesAsync();
            return true;

        }


        [Authorize(Roles = "client")]
        public async Task<IActionResult> DeleteTaxForm(int TaxID)
        {
            try
            {
                var taxForm=await _db.TaxDeclarations.FindAsync(TaxID);
                if (taxForm != null)
                {
                    NotFound();
                }
                _db.TaxDeclarations.Remove(taxForm);
                await _db.SaveChangesAsync();
                return RedirectToAction("PreviousSubmissions");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }

        }


        [Authorize(Roles = "client")]
        [HttpGet]
        public async Task<IActionResult> PreviousSubmissions()
        {
            try
            {
                ApplicationUser user = await GetCurrentUser();
                var userId = user.Id;
                var EmpId = user.EmpId;

                var taxForms = await _db.TaxDeclarations
                  .Where(td => td.EmpId == EmpId)
                  .OrderByDescending(td => td.FinancialYear)
                  .ToListAsync();

                List<TaxDeclarationViewModel> viewModelList = new List<TaxDeclarationViewModel>();

                foreach (var taxForm in taxForms)
                {
                    viewModelList.Add(new TaxDeclarationViewModel
                    {
                        EmpId = EmpId,
                        TaxId = taxForm.TaxId,
                        FinancialYear = taxForm.FinancialYear,
                        Status = taxForm.Status,
                        DateOfSubmission = taxForm.DateOfDeclaration,
                        isFrozen = taxForm.isFrozen,
                        isRejected = taxForm.isRejected,
                        isSubmitted = taxForm.isSubmitted,
                        isDrafted = taxForm.isDrafted,
                        isAccepted = taxForm.isAccepted,
                });
                }
                return View(viewModelList);
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }



        [Authorize(Roles = "client")]
        [HttpGet]
        public async Task<IActionResult> ChangeRequest(int TaxId)
        {
            ApplicationUser user = await GetCurrentUser();
            var model = new ChangeRequest();
            ViewBag.EmpId = user.EmpId;
            ViewBag.Name = user.Name;
            model.TaxId = TaxId;
            return View(model);
        }


        [Authorize(Roles = "client")]
        [HttpPost]
        public async Task<IActionResult>  ChangeRequest(ChangeRequest changeRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingRequest = await _db.ChangeRequests.FirstOrDefaultAsync(cr => cr.TaxId == changeRequest.TaxId);

                    if (existingRequest != null)
                    {
                        TempData["ErrorMessage"] = "A change request for this Tax Declaration has already been submitted.";
                        return View(changeRequest);
                    }

                    _db.ChangeRequests.Add(changeRequest);
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        TempData["SuccessMessage"] = "Request for change submitted successfully.";
                        return RedirectToAction("PreviousSubmissions", "Employee"); 
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to submit the request for change.");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An unexpected error occurred while processing your request.");
                }
            }
            return View(changeRequest);
        }


        [Authorize(Roles = "client")]

        [HttpPost]
        public async Task<IActionResult> ViewTaxForm(int TaxId)
        {
            try
            {
                var query = from taxDeclaration in _db.TaxDeclarations
                            where taxDeclaration.TaxId == TaxId
                            join user in _db.Users
                            on taxDeclaration.EmpId equals user.EmpId
                            select new
                            {
                                TaxDeclaration = taxDeclaration,
                                ApplicationUser = user
                            };


                var model = await query.FirstOrDefaultAsync();
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }

        private Task<ApplicationUser> GetCurrentUser() => _userManager.GetUserAsync(HttpContext.User);

        private async Task<TaxDeclaration> GetTaxByFinancialYearAndEmpId(int financialYear, int empId)
        {
            var taxDeclaration = await _db.TaxDeclarations.FirstOrDefaultAsync(td => td.FinancialYear == financialYear && td.EmpId == empId);
            return taxDeclaration;
        }

        public IActionResult Error(string? ErrMsg)
        {
            ViewBag.ErrMsg = ErrMsg;
            return View();
        }
    }
}
