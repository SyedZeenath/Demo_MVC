using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RestaurantItemsController : Controller
    {
        private ZeedbEntities db = new ZeedbEntities();

        // GET: RestaurantItems
        public ActionResult Index()
        {
            return View(db.RestaurantItems.ToList());
        }

        // GET: RestaurantItems/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantItem restaurantItem = db.RestaurantItems.Find(id);
            if (restaurantItem == null)
            {
                return HttpNotFound();
            }
            return View(restaurantItem);
        }

        // GET: RestaurantItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] RestaurantItem restaurantItem)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantItems.Add(restaurantItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantItem);
        }

        // GET: RestaurantItems/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantItem restaurantItem = db.RestaurantItems.Find(id);
            if (restaurantItem == null)
            {
                return HttpNotFound();
            }
            return View(restaurantItem);
        }

        // POST: RestaurantItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] RestaurantItem restaurantItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantItem);
        }

        // GET: RestaurantItems/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantItem restaurantItem = db.RestaurantItems.Find(id);
            if (restaurantItem == null)
            {
                return HttpNotFound();
            }
            return View(restaurantItem);
        }

        // POST: RestaurantItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            RestaurantItem restaurantItem = db.RestaurantItems.Find(id);
            db.RestaurantItems.Remove(restaurantItem);
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
