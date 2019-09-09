
namespace FinancialPortal.Helpers
{
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using System.Web;

    public abstract class InstanceHelper
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();

        protected static string Me { get; set; } = HttpContext.Current.User.Identity.GetUserId();

        protected static string GetMyId()
        {
            var me = HttpContext.Current.User.Identity.GetUserId();
            return me;
        }


    }
}