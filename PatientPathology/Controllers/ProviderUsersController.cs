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
    public class ProviderUsersController : Controller
    {
        private PtPathContext db = new PtPathContext();

        // GET: ProviderUsers
        public ActionResult Index()
        {
            return View(db.ProviderUser.ToList());
        }

        // GET: ProviderUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderUser providerUser = db.ProviderUser.Find(id);
            if (providerUser == null)
            {
                return HttpNotFound();
            }
            return View(providerUser);
        }

        // GET: ProviderUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviderUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProviderUserId,Email")] ProviderUser providerUser)
        {
            if (ModelState.IsValid)
            {
                db.ProviderUser.Add(providerUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providerUser);
        }

        // GET: ProviderUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderUser providerUser = db.ProviderUser.Find(id);
            if (providerUser == null)
            {
                return HttpNotFound();
            }
            return View(providerUser);
        }

        // POST: ProviderUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProviderUserId,Email")] ProviderUser providerUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerUser);
        }

        // GET: ProviderUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderUser providerUser = db.ProviderUser.Find(id);
            if (providerUser == null)
            {
                return HttpNotFound();
            }
            return View(providerUser);
        }

        // POST: ProviderUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderUser providerUser = db.ProviderUser.Find(id);
            db.ProviderUser.Remove(providerUser);
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
