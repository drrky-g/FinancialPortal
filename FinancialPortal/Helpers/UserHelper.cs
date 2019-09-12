namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity.Owin;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class UserHelper
    {
        public ApplicationUser AssignRegisterPropertiesToUser(RegisterViewModel model, string avatarUrl)
        {
            var newUser = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Alias = model.Alias,
                AvatarPath = avatarUrl
            };
            return newUser;
        }
    }
}