namespace FinancialPortal.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using FinancialPortal.Helpers;
    using FinancialPortal.Models;
    using FinancialPortal.ViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    //[Authorize]
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private HouseholdHelper houseHelper = new HouseholdHelper();
        private UserHelper userHelper = new UserHelper();
        private ImageUploader imageHelper = new ImageUploader();
        private WizardHelper wizardHelper = new WizardHelper();
        private BankAccountHelper accountHelper = new BankAccountHelper();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public HouseholdsController() { }

        //dependency injection
        public HouseholdsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
        }

        //GET: CreateHouseWithWizard
        public ActionResult CreateHouseWithWizard()
        {
            var accountVM = new CreateAccountVM
            {
                BAccountType = accountHelper.GetAccountTypeSelectList()
            };
            var wizard = new HouseWizardVM
            {
                CreateAccount = accountVM
            };
            return View(wizard);
        }

        //POST: CreateHouseWithWizard
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHouseWithWizard(HouseWizardVM model)
        {
            var houseId = wizardHelper.ManageWizard(model);
            db.SaveChanges();
            return RedirectToAction("Details", "Households", new { id = houseId });
        }

        // GET: CreateHouse
        public ActionResult CreateHouse()
        {
            return View();
        }

        // POST: CreateHouse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHouse(CreateHouseVM model)
        {
            var newHouse = houseHelper.CreateNewHousehold(model);
            return RedirectToAction("Details", "Households", new { id = newHouse.Id});
        }

        //POST: JoinHouse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JoinHouse(int id)
        {
            houseHelper.AddHouseMember(id);
            return RedirectToAction("Details", new { id });
        }

        //GET: SendHouseInvitation
        public ActionResult SendHouseInvitation(int id)
        {
            var invite = new InviteVM { HouseholdId = id };
            return View(invite);
        }

        //POST: SendHouseInvitation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendHouseInvitation(InviteVM model)
        {
            var invite = houseHelper.CreateInvite(model);
            await houseHelper.SendHouseInvite(invite);
            return RedirectToAction("Details", "Households", new { id = model.HouseholdId });
        }

        //GET: AcceptHouseInvite
        public ActionResult AcceptHouseInvite(int id, Guid code)
        {
            var invite = db.Invitations.FirstOrDefault(i => i.Code == code);
            if(DateTime.Now < invite.Expire)
            {
                var register = new InviteRegisterVM { HouseholdId = id, Email = invite.EmailTo };
                return View(register);
            }
            else
            {
                return RedirectToAction("InviteExpire", "Households");
            }
            
        }

        //POST: AcceptHouseInvite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AcceptHouseInvite(InviteRegisterVM model, HttpPostedFileBase AvatarPath)
        {
            var house = db.Households.FirstOrDefault(h => h.Id == model.HouseholdId);
            var image = imageHelper.StoreAvatar(AvatarPath);
            if (ModelState.IsValid)
            {
                //check to see if this email is already associated with a user in the application
                var email = db.Users.FirstOrDefault(user => user.Email == model.Email);
                if(email == null)
                {   var newUser = userHelper.AssignRegisterPropertiesToUser(model, image);
                    newUser.UserName = model.Email;
                    var result = await UserManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        UserManager.AddToRole(newUser.Id, "HouseholdMember");
                        await SignInManager.SignInAsync(newUser, isPersistent: false, rememberBrowser: false);
                        await houseHelper.AddToHouseAsync(newUser.Id, model.HouseholdId);
                        return RedirectToAction("Details", "Households", new { id = model.HouseholdId });
                    }
                    else { return View(model); };
                }
                else
                {
                    //redirect to a view that tells user their email is already associated with an account
                    return RedirectToAction("AccountExists", "Households");
                }
            }
            return View(model);
        }

        //GET: Error
        public ActionResult Error()
        {
            ViewBag.Error = "An error occured.";
            return View();
        }

        //GET: AccountExists
        public ActionResult AccountExists()
        {
            ViewBag.Error = "A user with this email already exists. Please sign in with that account.";
            return View("Error");
        }

        //GET: InviteExpire
        public ActionResult InviteExpire()
        {
            ViewBag.Error = "Your invitation expired. Please request another invitation to this house.";
            return View("Error");
        }

        //POST: LeaveHouse
        public ActionResult LeaveHouse(int id)
        {
            var myId = User.Identity.GetUserId();
            var me = db.Users.FirstOrDefault(m => m.Id == myId);
            var house = db.Households.FirstOrDefault(h => h.Id == id);
            if (houseHelper.ImHeadOfHousehold(house) && house.Users.Count > 1)
            {
                //Redirect to a page that lets HoH
                //pass HoHId to somebody else
                return RedirectToAction("???", "Households");
            }
            else
            {
                houseHelper.LeaveHouse(house);
                return me.Households.Count() > 0 ? RedirectToAction("Lobby", "Home") : RedirectToAction("Index");
            }
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created,Description,HeadOfHouseId")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = household.Id});
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
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
