namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using System.Web;
    using System;
    using System.Collections.Generic;
    using FinancialPortal.ViewModels;
    using System.Linq;

    public class HouseholdHelper : InstanceHelper
    {
        //this was made for seeding....
        public void AddUserToHousehold(string userId, int householdId)
        {
            var household = db.Households.Find(householdId);
            var me = db.Users.Find(userId);
            //TODO : Prevent a head of household from joining a household that already has one?
            // can users have multiple roles depending on their household?
            
                household.Users.Add(me);
                db.SaveChanges();
        }

        public Household CreateNewHousehold(CreateHouseVM model)
        {
            var newHouse = new Household
            {
                Name = model.Name,
                Created = DateTime.Now,
                Description = model.Description,
                HeadOfHouseId = Me,
            };
            var me = db.Users.Find(Me);
            newHouse.Users.Add(me);
            db.Households.Add(newHouse);
            db.SaveChanges();
            return newHouse;
        }
        public void AddHouseMember(int houseId)
        {
            var me = db.Users.Find(GetMyId());
            var h = db.Households.Find(houseId);
            h.Users.Add(me);
            db.SaveChanges();
        }

        public void LeaveHouse(Household house)
        {
            var me = db.Users.Find(GetMyId());
            house.Users.Remove(me);
            db.SaveChanges();
            
        }

        public bool ImHeadOfHousehold(Household house)
        {

            return house.HeadOfHouseId == GetMyId();
        }

    }
}