using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_EntityFramework_Assignment2.Models;

namespace MVC_EntityFramework_Assignment2.Controllers
{
    public class BusInformationsController : Controller
    {
        private travelEntities db = new travelEntities();

        // GET: BusInformations
        public ActionResult Index()
        {
            return View(db.BusInformations.SqlQuery("Select * from businformation where BoardingPoint='mum'").ToList());
        }

        // GET: BusInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformations.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // GET: BusInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusID,BoardingPoint,TravelDate,Amount,Rating,DroppingPoint")] BusInformation busInformation)
        {
            if (ModelState.IsValid)
            {
                db.BusInformations.Add(busInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busInformation);
        }

        // GET: BusInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformations.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // POST: BusInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusID,BoardingPoint,TravelDate,Amount,Rating,DroppingPoint")] BusInformation busInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busInformation);
        }

        // GET: BusInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformations.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // POST: BusInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusInformation busInformation = db.BusInformations.Find(id);
            db.BusInformations.Remove(busInformation);
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
