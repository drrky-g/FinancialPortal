namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Helpers;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    public class CreateAccountVM : InstanceHelper
    {
        [Display(Name = "Account Name")]
        public string BName { get; set; }
        [Display (Name = "Account Description")]
        public string BDescription { get; set; }
        [Display (Name = "Starting Balance")]
        public float BStartingBalance { get; set; }
        [Display (Name = "Low Balance Threshold")]
        public float BLowBalanceThreshold { get; set; }
        //AccountType
        [Display (Name = "Account Type")]
        public int SelectedAccountTypeId { get; set; }
        public IEnumerable<SelectListItem> BAccountType { get; set; }
    }
}