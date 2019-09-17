namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Models;
    using System.ComponentModel.DataAnnotations;

    public class InviteRegisterVM : RegisterViewModel
    {
        [Required]
        public int HouseholdId { get; set; }
    }
}