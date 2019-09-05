using System.ComponentModel.DataAnnotations;

namespace FinancialPortal.ViewModels
{
    public class UserProfileVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string ProfilePicture { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}