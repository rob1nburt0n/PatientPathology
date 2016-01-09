using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientPathology.Models;

namespace PatientPathology.Controllers
{
    public class BiopsiesController : Controller
    {
        private PtPathContext db = new PtPathContext();

        // GET: Biopsies
        public ActionResult Index()
        {
            return View(db.Biopsy.ToList());
        }

        // GET: Biopsies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = db.Biopsy.Find(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // GET: Biopsies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biopsies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BiopsyID,BioDate,BioType,PathClassification,PathType,PatLastName,PatDOB,ProvLastName,TechnologistName")] Biopsy biopsy)
        {
            if (ModelState.IsValid)
            {
                db.Biopsy.Add(biopsy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biopsy);
        }

        // GET: Biopsies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = db.Biopsy.Find(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // POST: Biopsies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BiopsyID,BioDate,BioType,PathClassification,PathType,PatLastName,PatDOB,ProvLastName,TechnologistName")] Biopsy biopsy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biopsy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biopsy);
        }

        // GET: Biopsies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = db.Biopsy.Find(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // POST: Biopsies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biopsy biopsy = db.Biopsy.Find(id);
            db.Biopsy.Remove(biopsy);
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
