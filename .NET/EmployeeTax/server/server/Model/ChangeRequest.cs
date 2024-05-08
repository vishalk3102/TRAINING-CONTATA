using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class ChangeRequest
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Tax ID is required")]
        public int taxId { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public int empId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Financial Year is required")]
        public int financialYear { get; set; }

        [Required(ErrorMessage = "Date of Submission is required")]
        public string dateOfSubmission { get; set; }

        [Required(ErrorMessage = "Reason is required")]
        public string reason { get; set; }

    }
}
