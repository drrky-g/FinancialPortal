namespace FinancialPortal.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    public class BankAccountHelper : InstanceHelper
    {
        public IEnumerable<SelectListItem> GetAccountTypeSelectList()
        {
            //create a list of selectlist items based off of db account types
            List<SelectListItem> types = db.AccountTypes
                .Select(type => new SelectListItem
                {
                    Value = type.Id.ToString(),
                    Text = type.Name
                }).ToList();
            //set the default first selection
            var initialSelect = new SelectListItem()
            {
                Value = null,
                Text = "-- Account Type --"
            };
            //add default to the top
            types.Insert(0, initialSelect);
            return new SelectList(types, "Value", "Text");
        }
    }
}