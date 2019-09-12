namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web;
    public class WizardHelper : InstanceHelper
    {
        public void ManageWizard(HouseWizardVM model)
        {
            var houseId = CreateHouseAndGetId(model.CreateHouse);
            CreateAccount(model.CreateAccount, houseId);
            CreateBudget(model.CreateBudget, houseId);
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
            db.SaveChanges();
            return newHouse.Id;
        }

        public void CreateAccount(CreateAccountVM model, int houseId)
        {
            var newAccount = new BankAccount
            {
                Description = model.BDescription,
                StartingBalance = model.BStartingBalance,
                CurrentBalance = model.BCurrentBalance,
                LowBalanceThreshold = model.BLowBalanceThreshold,
                Created = DateTime.Now,
                HouseholdId = houseId,
                //TODO: figure out how to set a selectlist to a VM
                //AccountTypeId = model.BAccountType
            };
            db.Accounts.Add(newAccount);
            db.SaveChanges();
        }

        public void CreateBudget(CreateBudgetVM model, int houseId)
        {
            var newBudget = new Budget
            {
                Name = model.BudgetName,
                HouseholdId = houseId
            };
            db.Budgets.Add(newBudget);
            db.SaveChanges();
        }
    }
}