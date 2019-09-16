using System.ComponentModel.DataAnnotations;

namespace FinancialPortal.ViewModels
{
    public class CreateBudgetVM
    {
        [Display(Name = "Budget Name")]
        public string BudgetName { get; set; }
        [Display(Name = "Budget Cap")]
        public float BudgetCap { get; set; }
        
    }
}