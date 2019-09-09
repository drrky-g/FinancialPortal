namespace FinancialPortal.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class InviteVM
    {
        [EmailAddress]
        [Required]
        public string RecieverEmail { get; set; }
        [StringLength(280, ErrorMessage = "Invitation body must be below 280 characters")]
        public string InviteBody { get; set; }
        [Required]
        public int HouseholdId { get; set; }

    }
}