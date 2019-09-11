namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using System;
    using FinancialPortal.ViewModels;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using System.Net.Mail;
    using System.Web.Mvc;
    using System.Web;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public class HouseholdHelper : InstanceHelper
    {
        //this was made for seeding...
        public void AddUserToHousehold(string userId, int householdId)
        {
            var household = db.Households.FirstOrDefault(house => house.Id == householdId);
            var myUser = db.Users.Find(userId);
            household.Users.Add(myUser);
        }
        //this is used when you accept an email invite
        public async Task AddToHouseAsync(string userId, int householdId)
        {
            var h = db.Households.Find(householdId);
            var me = db.Users.Find(userId);
            h.Users.Add(me);
            me.Households.Add(h);
            await db.SaveChangesAsync();
        }

        public Household CreateNewHousehold(CreateHouseVM model)
        {
            var me = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            var newHouse = new Household
            {
                Name = model.Name,
                Created = DateTime.Now,
                Description = model.Description,
                HeadOfHouseId = HttpContext.Current.User.Identity.GetUserId(),
            };
            newHouse.Users.Add(me);
            db.Households.Add(newHouse);
            db.SaveChanges();
            return newHouse;
        }
        public void AddHouseMember(int houseId)
        {
            var me = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            var h = db.Households.Find(houseId);
            h.Users.Add(me);
            db.SaveChanges();
        }

        public void LeaveHouse(Household house)
        {
            var me =db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            house.Users.Remove(me);
            db.SaveChanges();
        }

        public bool ImHeadOfHousehold(Household house)
        {
            return house.HeadOfHouseId == HttpContext.Current.User.Identity.GetUserId();
        }

        public Invitation CreateInvite(InviteVM invite)
        {
            //will need to create a new viewmodel for this method..
            var now = DateTime.Now;
            var weekLater = now.AddDays(7);
            var me = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            var newInvite = new Invitation
            {
                Subject = $"{me.FirstName} invites you to join their house on MoneyApp!",
                Created = now,
                Expire = weekLater,
                Body = invite.InviteBody,
                EmailTo = invite.RecieverEmail,
                SenderId = me.Id,
                HouseholdId = invite.HouseholdId,
                Code = Guid.NewGuid()
            };
            db.Invitations.Add(newInvite);
            db.SaveChanges();
            return newInvite;
        }

        public async Task SendHouseInvite(Invitation invite)
        {
            //need to create an invitation somewhere first...
            var Url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var from = WebConfigurationManager.AppSettings["smtpEmailFrom"];
            var code = invite.Code;
            //link not working (may need to fill out UrlHelper overload/signatures?
            string cb = Url.Action("AcceptHouseInvite", "Households", new { id = invite.HouseholdId, code }, protocol: HttpContext.Current.Request.Url.Scheme);
            var email = new MailMessage(from, invite.EmailTo)
            {
                IsBodyHtml = true,
                Subject = invite.Subject,
                Body = $"{invite.Body} <hr /> Click <a href='{cb}' target='_blank'>here</a> to join this MoneyApp household."
            };
            var serve = new EmailService();
            await serve.SendAsync(email);
        }

    }
}