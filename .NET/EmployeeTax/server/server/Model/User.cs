using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class User
    {
        [Required]
        public int empId {  get; set; }

        [Required]
        public string password { get; set; }
    }
}
