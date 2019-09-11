namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Helpers;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CreateAccountVM : InstanceHelper
    {
        public string Description { get; set; }
        public float StartingBalance { get; set; }
        public float CurrentBalance { get; set; }
        public float LowBalanceThreshold { get; set; }
        public IEnumerable<SelectListItem> AccountType { get; set; } = new SelectList(db.AccountTypes, "Id", "Name");
        
        //still need a multiselectlist for accounttype
    }
}