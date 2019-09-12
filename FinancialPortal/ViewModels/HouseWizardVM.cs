using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.ViewModels
{
    public class HouseWizardVM
    {
        //combine:
        //1: create house
        public CreateHouseVM CreateHouse { get; set; }

        //2: create bank account 
        public CreateAccountVM CreateAccount { get; set; }

        //3: create budget
        public CreateBudgetVM CreateBudget { get; set; }
        //4: create budget item

    }
}