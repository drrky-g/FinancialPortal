using System;
using System.Collections.Generic;
using System.Data;
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

namespace FinancialPortal.Controllers
{
    [Authorize]
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private HouseholdHelper houseHelper = new HouseholdHelper();

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
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

        //POST: LeaveHouse
        public ActionResult LeaveHouse(int id)
        {
            var myId = User.Identity.GetUserId();
            var me = db.Users.FirstOrDefault(m => m.Id == myId);
            var house = db.Households.AsNoTracking().FirstOrDefault(h => h.Id == id);
            if (houseHelper.ImHeadOfHousehold(house) && house.Users.Count > 1)
            {
                //Redirect to a page that lets HoH
                //pass HoHId to somebody else
            }
            else
            {
                houseHelper.LeaveHouse(house);
                return me.Households.Count() > 0 ? RedirectToAction("Lobby", "Home") : RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { id });
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
                return RedirectToAction("Index");
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
