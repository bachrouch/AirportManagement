using Airport.Service;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class AirlineFlightController : Controller
    {
        IAirlineService afs=new AirlineService();
        public AirlineFlightController(IAirlineService afs)
        {
            this.afs = afs;
                
        }

        public AirlineFlightController() { }
        // GET: AirlineFlight
        public ActionResult Index()
        {
            var l = afs.GetMany();
            return View(l);
        }

        // GET: AirlineFlight/Details/5
        public ActionResult Details(int id)
        { 
            return View();
        }

        // GET: AirlineFlight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirlineFlight/Create
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

        // GET: AirlineFlight/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirlineFlight/Edit/5
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

        // GET: AirlineFlight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirlineFlight/Delete/5
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
