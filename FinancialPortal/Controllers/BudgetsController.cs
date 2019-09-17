namespace FinancialPortal.Controllers
{
    using FinancialPortal.Helpers;
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using System.Web.Mvc;

    public class BudgetsController : Controller
    {
        private WizardHelper wiz = new WizardHelper();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Budgets
        public ActionResult Index()
        {
            return View();
        }

        //GET: CreateBudget
        public ActionResult CreateBudget(int houseId)
        {
            var newBudget = new BudgetWithHouseVM { HouseholdId = houseId };
            return View(newBudget);
        }

        //POST: CreateBudget
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBudget(BudgetWithHouseVM model)
        {
            if (ModelState.IsValid)
            {
                wiz.CreateBudget(model, model.HouseholdId);
                db.SaveChanges();
                return RedirectToAction("Details", "Households", new { id = model.HouseholdId });
            };
            return View();
        }
    }
}