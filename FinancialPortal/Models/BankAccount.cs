using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string StartingBalance { get; set; }
        public string CurrentBalance { get; set; }
        public DateTime Created { get; set; }
        public int LowBalanceThreshold { get; set; }
        //
        //virtual
        public int HouseholdId { get; set; }
        public int AccountTypeId { get; set; }
        //------------------------------------------
        public virtual Household Household { get; set; }
        public virtual AccountType Type { get; set; }
        //
        //collections
        public virtual ICollection<Transaction> Transactions { get; set; }
        //
        //constructor
        public BankAccount()
        {
            this.Transactions = new HashSet<Transaction>();
        }

    }
}