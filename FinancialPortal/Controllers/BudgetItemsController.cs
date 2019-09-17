namespace FinancialPortal.Controllers
{
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using System.Web.Mvc;

    public class BudgetItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetItems
        public ActionResult Index()
        {
            return View();
        }

        //GET: Create BudgetItem
        public ActionResult CreateBudgetItem()
        {
            return View();
        }

        //POST: Create BudgetItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBudgetItem(CreateBudgetItemVM model)
        {
            return View();
        }
    }
}