using TaxManagementNew.Models.ViewModel;

namespace TaxManagementNew.Models.ViewModel
{
    public class TaxPaginationViewModel
    {
        public List<TaxDeclarationViewModel> TaxForms { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int? FinancialYear { get; set; }
        public string Name { get; set; }
        public int? EmpId { get; set; }
        public int PageSize { get; set; }
    }
}
