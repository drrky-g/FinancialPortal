using FinancialPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialPortal.ViewModels
{
    public class InviteRegisterVM : RegisterViewModel
    {
        [Required]
        public int HouseholdId { get; set; }
    }
}