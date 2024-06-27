using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TaxManagementNew.Models;
public class TaxDeclaration
{

    [Key]
    public int TaxId { get; set; }

    [Required(ErrorMessage = "Employee ID is required")]
    public int EmpId { get; set; }

    [Required(ErrorMessage = "Any other income is required")]
    public decimal AnyOtherIncome { get; set; }

    [Required(ErrorMessage = "Sukanya Samriddhi Account is required")]
    public decimal SukanyaSamriddhiAccount { get; set; }

    [Required(ErrorMessage = "Public Provident Fund (PPF) is required")]
    public decimal PPF { get; set; }

    [Required(ErrorMessage = "Life Insurance Premium is required")]
    public decimal LifeInsurancePremium { get; set; }

    [Required(ErrorMessage = "Tuition Fee is required")]
    public decimal TuitionFee { get; set; }

    [Required(ErrorMessage = "Bank Fixed Deposit is required")]
    public decimal BankFixedDeposit { get; set; }

    [Required(ErrorMessage = "Principal Housing Loan is required")]
    public decimal PrincipalHousingLoan { get; set; }

    [Required(ErrorMessage = "National Pension Scheme (NPS) is required")]
    public decimal NPS { get; set; }

    [Required(ErrorMessage = "Higher Education Loan Interest is required")]
    public decimal HigherEducationLoanInterest { get; set; }

    [Required(ErrorMessage = "Interest on Housing Loan is required")]
    public decimal InterestHousingLoan { get; set; }

    [Required(ErrorMessage = "House Rent is required")]
    public decimal HouseRent { get; set; }

    [Required(ErrorMessage = "TDS (Tax Deducted at Source) is required")]
    public decimal TDS { get; set; }

    [Required(ErrorMessage = "Mediclaim is required")]
    public decimal MediClaim { get; set; }

    [Required(ErrorMessage = "Preventive Health Check-Up is required")]
    public decimal PreventiveHealthCheckUp { get; set; }

    [Required(ErrorMessage = "Leave Travel Allowance (LTA) is required")]
    public bool LTA { get; set; }

    [Required(ErrorMessage = "Financial Year is required")]
    public int FinancialYear { get; set; }

    [Required(ErrorMessage = "Frozen status is required")]
    public bool isFrozen { get; set; }

    [Required(ErrorMessage = "Date of Declaration is required")]
    public string DateOfDeclaration { get; set; }

    public string Status { get; set; } = "pending";

    public bool isSubmitted { get; set; }

    public bool isDrafted { get; set; }
    public bool isAccepted { get; set; }
    public bool isRejected { get; set; }


}