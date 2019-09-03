using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        //collection
        public ICollection<BankAccount> Accounts { get; set; }
        //
        //constructor
        public AccountType()
        {
            this.Accounts = new HashSet<BankAccount>();
        }
    }
}