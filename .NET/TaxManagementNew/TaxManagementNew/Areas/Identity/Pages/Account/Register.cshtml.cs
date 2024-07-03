using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaxManagementNew.Models;

namespace TaxManagementNew.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Employee ID is required")]
            [Display(Name = "Employee ID")]
            public int EmpId { get; set; }

            [Required(ErrorMessage = "Name is required")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Age is required")]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Date of birth is required")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "PAN number is required")]
            [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]$", ErrorMessage = "Please enter a valid PAN number.(format ABCTY1234D)")]
            [Display(Name = "PAN Number")]
            public string PanNo { get; set; }

            [Required(ErrorMessage = "Address is required")]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                if (Input.PanNo.Length >= 5 && !string.IsNullOrEmpty(Input.Name))
                {
                    var nameParts = Input.Name.Split(' ');
                    if (nameParts.Length > 1)
                    {
                        var surnameInitial = char.ToUpper(nameParts[^1][0]); 
                        if (Input.PanNo[4] != surnameInitial)
                        {
                            ModelState.AddModelError(nameof(Input.PanNo), "Invalid Pan Card.");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(Input.Name), "Please enter the full name with at least a surname.");
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "PAN number or Name is not in the correct format.");
                }

                var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.PanNo == Input.PanNo);
                if (existingUser != null)
                {
                    ModelState.AddModelError(nameof(Input.PanNo), "This PAN number is already in use. Please use a different PAN number.");
                    return Page();
                }

                int age = CalculateAge(Input.DateOfBirth);

                var user = new ApplicationUser
                {
                    UserName = Input.EmpId.ToString(),
                    EmpId = Input.EmpId,
                    Name = Input.Name,
                    Age = age,
                    DateOfBirth = Input.DateOfBirth,
                    PhoneNumber = Input.PhoneNumber,
                    PanNo = Input.PanNo,
                    Address = Input.Address
                };

                try
                {
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _userManager.AddToRoleAsync(user, "client");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    // Check if the exception is due to duplicate PAN
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                        (sqlEx.Number == 2601 || sqlEx.Number == 2627) &&
                        sqlEx.Message.Contains("IX_AspNetUsers_PanNo"))
                    {
                        ModelState.AddModelError(nameof(Input.PanNo), "This PAN number is already in use. Please use a different PAN number.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "An error occurred while creating your account. Please try again later.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}