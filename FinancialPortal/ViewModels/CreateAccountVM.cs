namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Helpers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class CreateAccountVM : InstanceHelper
    {
        public BankAccountHelper accountHelper = new BankAccountHelper();

        public string BName { get; set; }
        public string BDescription { get; set; }
        public float BStartingBalance { get; set; }
        public float BCurrentBalance { get; set; }
        public float BLowBalanceThreshold { get; set; }
        //AccountType
        public int SelectedAccountTypeId { get; set; }
        public IEnumerable<SelectListItem> BAccountType { get; set; }
    }
}