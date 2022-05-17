using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Assignment1_Program2.Models;

namespace MVC_Assignment1_Program2.Controllers
{
    public class FootBallLeaguesController : Controller
    {
        private FootBallDBContext db = new FootBallDBContext();

        // GET: FootBallLeagues
        public ActionResult Index()
        {
            return View(db.FootBallLeagues.ToList());
        }

        // GET: FootBallLeagues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootBallLeague footBallLeague = db.FootBallLeagues.Find(id);
            if (footBallLeague == null)
            {
                return HttpNotFound();
            }
            return View(footBallLeague);
        }

        // GET: FootBallLeagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootBallLeagues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,TeamName1,TeamName2,MatchStatus,WinningTeam")] FootBallLeague footBallLeague)
        {
            if (ModelState.IsValid)
            {
                db.FootBallLeagues.Add(footBallLeague);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footBallLeague);
        }

        // GET: FootBallLeagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootBallLeague footBallLeague = db.FootBallLeagues.Find(id);
            if (footBallLeague == null)
            {
                return HttpNotFound();
            }
            return View(footBallLeague);
        }

        // POST: FootBallLeagues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,TeamName1,TeamName2,MatchStatus,WinningTeam")] FootBallLeague footBallLeague)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footBallLeague).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footBallLeague);
        }

        // GET: FootBallLeagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootBallLeague footBallLeague = db.FootBallLeagues.Find(id);
            if (footBallLeague == null)
            {
                return HttpNotFound();
            }
            return View(footBallLeague);
        }

        // POST: FootBallLeagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FootBallLeague footBallLeague = db.FootBallLeagues.Find(id);
            db.FootBallLeagues.Remove(footBallLeague);
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
