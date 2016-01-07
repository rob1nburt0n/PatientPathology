using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPathology.Controllers
{
    public class ProviderUserController : Controller
    {
        // GET: ProviderUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProviderUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProviderUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProviderUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProviderUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProviderUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProviderUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProviderUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
