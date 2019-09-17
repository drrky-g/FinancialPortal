
namespace FinancialPortal.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateHouseVM
    {
        [Required]
        [Display (Name = "House Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "House Description")]
        public string Description { get; set; }
    }
}