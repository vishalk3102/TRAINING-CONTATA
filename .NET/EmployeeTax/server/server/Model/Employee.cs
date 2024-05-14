using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Model
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public string dateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "PAN number is required")]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]$", ErrorMessage = "Please enter a valid PAN number.(format ABCTY1234D )")]
        public string panNo { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string role { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string password { get; set; }
    }
}