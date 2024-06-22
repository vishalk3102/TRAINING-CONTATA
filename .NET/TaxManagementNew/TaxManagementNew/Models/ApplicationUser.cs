using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaxManagementNew.Models;

public class ApplicationUser : IdentityUser
{
    [Key]
    public int EmpId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "PAN number is required")]
    [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]$", ErrorMessage = "Please enter a valid PAN number.(format ABCTY1234D)")]
    public string PanNo { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

}

