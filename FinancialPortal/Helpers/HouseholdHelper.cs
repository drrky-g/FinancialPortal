using FinancialPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortal.Helpers
{
    public class HouseholdHelper 
    {

        public ApplicationDbContext db = new ApplicationDbContext();

        public void AddUserToHousehold(string userId, int householdId)
        {
            var household = db.Households.Find(householdId);
            var me = db.Users.Find(userId);
            //TODO : Prevent a head of household from joining a household that already has one?
            // can users have multiple roles depending on their household?
            
                household.Users.Add(me);
                db.SaveChanges();
        }
    }
}