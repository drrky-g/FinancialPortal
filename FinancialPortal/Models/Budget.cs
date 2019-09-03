﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        //virtual
        public int HouseholdId { get; set; }
        //-----------------------------------------
        public virtual Household Household { get; set; }
        //
        //collections
        public virtual ICollection<BudgetItem> BudgetItems { get; set; }
        //constructor
        public Budget()
        {
            this.BudgetItems = new HashSet<BudgetItem>();
        }

    }
}