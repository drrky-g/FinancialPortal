using FinancialPortal.Models;

namespace FinancialPortal.Helpers
{
    public abstract class InstanceHelper
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();

    }
}