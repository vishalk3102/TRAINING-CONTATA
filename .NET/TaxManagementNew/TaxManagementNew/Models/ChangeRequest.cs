using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TaxManagementNew.Models;
public class ChangeRequest
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tax ID is required")]
    public int TaxId { get; set; }

    [Required(ErrorMessage = "Reason is required")]
    public string Reason { get; set; }

}