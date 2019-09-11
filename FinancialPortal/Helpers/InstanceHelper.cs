
namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using System.Web;

    public abstract class InstanceHelper
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();

        //have to set this line to an empty string when seeding...need to fix that
        //protected static string myId = HttpContext.Current.User.Identity.GetUserId();

        //protected static ApplicationUser me = db.Users.Find(myId);
    }
}