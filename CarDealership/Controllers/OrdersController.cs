using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
   
    public class OrdersController : Controller
    {
        private DealershipContext db = new DealershipContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Owners.ToList());
        }

        [Authorize(Roles = "User")]
        public ActionResult Checkout()
        {
            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var vm = new Owner();
            var carSelection = db.Cars.ToList().Select(x => new {x.Id, Name = $"{x.Year} - {x.Manufacture} {x.Model} {x.Price}"});
            vm.AvailableCars = new SelectList(carSelection, "Id", "Name");
            return View(vm);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,SelectedCar")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                if (owner.SelectedCar > 0)
                {
                    owner.Cars.Add(db.Cars.Find(owner.SelectedCar));
                }

                db.Owners.Add(owner);
                db.SaveChanges();
                return View("Checkout", owner);
            }

            return View(owner);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = db.Owners.Find(id);
            db.Owners.Remove(owner);
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
