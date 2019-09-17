using System.ComponentModel.DataAnnotations;

namespace FinancialPortal.ViewModels
{
    public class CreateBudgetVM
    {
        [Required]
        [Display(Name = "Budget Name")]
        public string BudgetName { get; set; }
        [Required]
        [Display(Name = "Budget Cap")]
        public float BudgetCap { get; set; }
        
    }

    public class BudgetWithHouseVM : CreateBudgetVM
    {
        [Required]
        [Display (Name = "Household")]
        public int HouseholdId { get; set; }
    }
}