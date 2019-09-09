namespace FinancialPortal.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserProfileVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string ProfilePicture { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}