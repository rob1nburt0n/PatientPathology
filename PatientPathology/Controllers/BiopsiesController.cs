using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientPathology.Models;
using Microsoft.AspNet.Identity;

namespace PatientPathology.Controllers
{
    public class BiopsiesController : Controller
    {
        public PtPathRepository Repo { get; set; }

        public BiopsiesController() : base()
        {
            Repo = new PtPathRepository();
        }

        // GET: Biopsies

        private PtPathContext db = new PtPathContext();
        [Authorize]
        public ActionResult Index(string SearchBy, string search)

        {
            List<Biopsy> list_of_biopsies = Repo.GetAllBiopsies();
            if (SearchBy == "BioDate")
            {
                return View(db.Biopsy.Where(x => x.BioDate.Contains(search)).ToList());
            }
            else if (SearchBy == "BioType")
            {
                return View(db.Biopsy.Where(x => x.BioType.Contains(search)).ToList());
            }
            else if (SearchBy == "PathClassification")
            {
                return View(db.Biopsy.Where(x => x.PathClassification.Contains(search)).ToList());
            }
            else if (SearchBy == "PathType")
            {
                return View(db.Biopsy.Where(x => x.PathType.Contains(search)).ToList());
            }
            else if (SearchBy == "PatLastName")
            {
                return View(db.Biopsy.Where(x => x.PatLastName.StartsWith(search)).ToList());
            }
            else if (SearchBy == "PatDOB")
            {
                return View(db.Biopsy.Where(x => x.PatDOB.Contains(search)).ToList());
            }
            else if (SearchBy == "ProvLastName")
            {
                return View(db.Biopsy.Where(x => x.ProvLastName.StartsWith(search)).ToList());
            }
            else if (SearchBy == "TechnologistName")
            {
                return View(db.Biopsy.Where(x => x.TechnologistName.StartsWith(search)).ToList());
            }

            return View(list_of_biopsies);
           
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
