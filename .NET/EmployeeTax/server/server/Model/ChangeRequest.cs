using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class ChangeRequest
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tax ID is required")]
        public int taxId { get; set; }

        [Required(ErrorMessage = "Reason is required")]
        public string reason { get; set; }

    }
}
