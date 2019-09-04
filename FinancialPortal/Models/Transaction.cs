namespace FinancialPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        //
        //virtual
        public int TypeId { get; set; }
        public int AccountId { get; set; }
        public string UserId { get; set; }
        public int? BudgetItemId { get; set; }
        //------------------------------------------
        public virtual TransactionType Type { get; set; }
        public virtual BankAccount Account { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual BudgetItem BudgetItem { get; set; }
    }
}