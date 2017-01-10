using Airport.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Airport.Domain.Entities;

namespace GUI.Controllers
{
    public class FlightController : Controller
    {
        FlightService FlightService=new FlightService();
        public FlightController() { }
        public FlightController(FlightService FlightService)
        {
            this.FlightService = FlightService;

        }
      
        public ActionResult index(string Search_Data="", string Departure_Time="")
        {
            var listFlights = FlightService.getAllFlights();
            var flights = from flight in listFlights select flight;
            {
               flights = flights.Where(flight => flight.destination.ToUpper().Contains(Search_Data.ToUpper())
                 && flight.startTime.ToUpper().Contains(Departure_Time.ToUpper())).OrderBy(flight=>flight.price);
            }
            return View(flights.ToList());
        }
       

        public ActionResult SearchFlight()
        {
           //var listFlights = FlightService.getAllFlightsByDestinationAndStartTime(Search_Data, Departure_Time);
            return View();
        }
        //public ActionResult SearchFlight1(string Search_Data, string Departure_Time)
        //{
        //    var listFlights = FlightService.getAllFlightsByDestinationAndStartTime(Search_Data, Departure_Time);
        //    return RedirectToAction("Index",new {list =listFlights});
        //}

        // GET: Flight
        public ActionResult GetAllFlights()
        {
            var listFlights = FlightService.getAllFlights();
            return View(listFlights.ToList());
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
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

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flight/Edit/5
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

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flight/Delete/5
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
