namespace FinancialPortal.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using FinancialPortal.Helpers;

    public class BankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BankAccountHelper bank = new BankAccountHelper();
        private WizardHelper wizard = new WizardHelper();

        // GET: BankAccounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(b => b.Household).Include(b => b.Type);
            return View(accounts.ToList());
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.Accounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create(int houseId)
        {
            var createAccount = new AccountWithHouseVM
            {
                HouseholdId = houseId,
                BAccountType = bank.GetAccountTypeSelectList()
            };
            return View(createAccount);
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,StartingBalance,CurrentBalance,Created,LowBalanceThreshold,HouseholdId,AccountTypeId")] AccountWithHouseVM model)
        {
            

            if (ModelState.IsValid)
            {
                wizard.CreateAccount(model, model.HouseholdId);
                db.SaveChanges();
                return RedirectToAction("Details", "Households", new { id = model.HouseholdId });
            }
            return View(model);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.Accounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", bankAccount.HouseholdId);
            ViewBag.AccountTypeId = new SelectList(db.Accounts, "Id", "Name", bankAccount.AccountTypeId);
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,StartingBalance,CurrentBalance,Created,LowBalanceThreshold,HouseholdId,AccountTypeId")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", bankAccount.HouseholdId);
            ViewBag.AccountTypeId = new SelectList(db.Accounts, "Id", "Name", bankAccount.AccountTypeId);
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.Accounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankAccount bankAccount = db.Accounts.Find(id);
            db.Accounts.Remove(bankAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
