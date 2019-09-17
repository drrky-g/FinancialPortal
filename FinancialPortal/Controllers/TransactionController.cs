

namespace FinancialPortal.Controllers
{
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using System.Web.Mvc;

    public class TransactionController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        //GET: CreateAccount
        public ActionResult CreateAccount()
        {
            return View();
        }

        //POST: CreateAccount
        public ActionResult CreateAccount(TransactionVM model)
        {
            return View();
        }
    }
}