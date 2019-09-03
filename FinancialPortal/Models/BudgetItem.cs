using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        //virtual
        public int BudgetId { get; set; }
        //------------------------------------------
        public virtual Budget Budget { get; set; }
    }
}