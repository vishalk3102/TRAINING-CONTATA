namespace TaxManagementNew.Models.ViewModel
{
    public class TaxDeclarationViewModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int FinancialYear { get; set; }
        public string DateOfSubmission { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int TaxId { get; set; }
        public bool isSubmitted { get; set; }

        public bool isDrafted { get; set; }
        public bool isAccepted { get; set; }
        public bool isRejected { get; set; }
    }
}
