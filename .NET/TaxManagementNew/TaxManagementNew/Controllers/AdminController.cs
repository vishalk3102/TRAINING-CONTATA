using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using TaxManagementNew.Data;
using TaxManagementNew.Models;

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
        public async Task<IActionResult> TaxDeclaration()
        {
            try
            {
               var  taxFormList= await _db.TaxDeclarations.ToListAsync();
                if(!taxFormList.Any())
                {
                    return NotFound("No Tax Form Found");
                }
                return View(taxFormList);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Submission()
        {

            try
            {
                var taxFormList = await _db.TaxDeclarations.ToListAsync();
                if (!taxFormList.Any())
                {
                    return NotFound("No Tax Form Found");
                }
                return View(taxFormList);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { msg = e.Message });
            }
        }
    }
}
