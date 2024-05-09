using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace server.Model
{
    public class TaxDeclaration
    {

        [Key]
        public int taxId { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public int empId { get; set; }


        [Required(ErrorMessage = "Any other income is required")]
        public decimal anyOtherIncome { get; set; }

        [Required(ErrorMessage = "Sukanya Samriddhi Account is required")]
        public decimal sukanyaSamriddhiAccount { get; set; }

        [Required(ErrorMessage = "Public Provident Fund (PPF) is required")]
        public decimal PPF { get; set; }

        [Required(ErrorMessage = "Life Insurance Premium is required")]
        public decimal lifeInsurancePremium { get; set; }

        [Required(ErrorMessage = "Tuition Fee is required")]
        public decimal tuitionFee { get; set; }

        [Required(ErrorMessage = "Bank Fixed Deposit is required")]
        public decimal bankFixedDeposit { get; set; }

        [Required(ErrorMessage = "Principal Housing Loan is required")]
        public decimal principalHousingLoan { get; set; }

        [Required(ErrorMessage = "National Pension Scheme (NPS) is required")]
        public decimal NPS { get; set; }

        [Required(ErrorMessage = "Higher Education Loan Interest is required")]
        public decimal higherEducationLoanInterest { get; set; }

        [Required(ErrorMessage = "Interest on Housing Loan is required")]
        public decimal interestHousingLoan { get; set; }

        [Required(ErrorMessage = "House Rent is required")]
        public decimal houseRent { get; set; }

        [Required(ErrorMessage = "TDS (Tax Deducted at Source) is required")]
        public decimal TDS { get; set; }

        [Required(ErrorMessage = "Mediclaim is required")]
        public decimal mediClaim { get; set; }

        [Required(ErrorMessage = "Preventive Health Check-Up is required")]
        public decimal preventiveHealthCheckUp { get; set; }

        [Required(ErrorMessage = "Leave Travel Allowance (LTA) is required")]
        public bool LTA { get; set; }

        [Required(ErrorMessage = "Financial Year is required")]
        public int financialYear { get; set; }

        [Required(ErrorMessage = "Frozen status is required")]
        public bool isFrozen { get; set; }


        [Required(ErrorMessage = "Date of Declaration is required")]
        public string dateOfDeclaration { get; set; }

        public string status { get; set; } = "pending";


    }
}