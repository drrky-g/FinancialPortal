namespace FinancialPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Notification
    {
        //overdraft notification
        //low balance notification

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public bool ReadStatus { get; set; }
        //
        //virtual
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public int HouseholdId { get; set; }
        //------------------------------------------
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Reciever { get; set; }
        public virtual Household Household { get; set; }
    }
}