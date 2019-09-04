

namespace FinancialPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class Invitation
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [EmailAddress]
        public string EmailTo { get; set; }
        //
        //virtual
        public string SenderId { get; set; }
        //------------------------------------------
        public virtual ApplicationUser Sender { get; set; }

    }
}