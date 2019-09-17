namespace FinancialPortal.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateAccountVM
    {
        [Required]
        [Display(Name = "Account Name")]
        public string BName { get; set; }
        [Required]
        [Display (Name = "Account Description")]
        public string BDescription { get; set; }
        [Required]
        [Display (Name = "Starting Balance")]
        public float BStartingBalance { get; set; }
        [Display (Name = "Low Balance Threshold")]
        public float BLowBalanceThreshold { get; set; }

        //Type SelectList
        [Required]
        [Display (Name = "Account Type")]
        public int SelectedAccountTypeId { get; set; }
        public IEnumerable<SelectListItem> BAccountType { get; set; }
    }

    public class AccountWithHouseVM : CreateAccountVM
    {
        [Required]
        [Display(Name = "Household")]
        public int HouseholdId { get; set; }
    }
}