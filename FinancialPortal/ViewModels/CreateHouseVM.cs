using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialPortal.ViewModels
{
    public class CreateHouseVM
    {
        [Display (Name = "House Name")]
        public string Name { get; set; }
        [Display(Name = "House Description")]
        public string Description { get; set; }
    }
}