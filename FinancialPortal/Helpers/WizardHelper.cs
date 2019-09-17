namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web;

    public class WizardHelper : InstanceHelper
    {
        /// <summary>
        /// Pass 'House Wizard' View Model and create the house, budget, and account associated with the form
        /// </summary>
        /// <param name="model">HouseWizardVM</param>
        /// <returns>houseId</returns>
        public int ManageWizard(HouseWizardVM model)
        {
            var houseId = CreateHouseAndGetId(model.CreateHouse);
            CreateAccount(model.CreateAccount, houseId);
            CreateBudget(model.CreateBudget, houseId);
            return houseId;
        }

        public int CreateHouseAndGetId(CreateHouseVM model)
        {
            //create a new house and return the id of the house for reference with other methods
            var myId = HttpContext.Current.User.Identity.GetUserId();
            var me = db.Users.Find(myId);
            var newHouse = new Household
            {
                Name = model.Name,
                Created = DateTime.Now,
                Description = model.Description,
                HeadOfHouseId = myId
            };
            newHouse.Users.Add(me);
            db.Households.Add(newHouse);
            return newHouse.Id;
        }

        public void CreateAccount(CreateAccountVM model, int houseId)
        {
            var newAccount = new BankAccount
            {
                Description = model.BDescription,
                StartingBalance = model.BStartingBalance,
                CurrentBalance = model.BStartingBalance,
                LowBalanceThreshold = model.BLowBalanceThreshold,
                Created = DateTime.Now,
                HouseholdId = houseId,
                AccountTypeId = model.SelectedAccountTypeId
            };
            db.Accounts.Add(newAccount);
        }

        public void CreateBudget(CreateBudgetVM model, int houseId)
        {
            var newBudget = new Budget
            {
                Name = model.BudgetName,
                HouseholdId = houseId
            };
            db.Budgets.Add(newBudget);
        }
    }
}