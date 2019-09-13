using FinancialPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace FinancialPortal.ViewModels
{
    public class InviteRegisterVM : RegisterViewModel
    {
        [Required]
        public int HouseholdId { get; set; }
    }
}