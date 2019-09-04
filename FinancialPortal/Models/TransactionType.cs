namespace FinancialPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        //collection
        public virtual ICollection<Transaction> Transactions { get; set; }
        //
        //constructor
        public TransactionType()
        {
            this.Transactions = new HashSet<Transaction>();
        }

    }
}