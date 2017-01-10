using Airport.Domain.Entities;
using Airport.Service;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class FlightUserController : Controller
    {
        // GET: FlightUser
        IFlightService ause = new FlightService();
        public FlightUserController(IFlightService ause)
        {
            this.ause = ause;
        }
        public FlightUserController() { }
        // GET: Flight
        public ActionResult Index(string Search_Data = "", string Daparture_Time = "")
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            var listFlights = ause.getAllFlights();
            var flights = from flight in listFlights select flight;
            {
               flights = flights.Where(flight => flight.destination.ToUpper().Contains(Search_Data.ToUpper())
                 && flight.startTime.ToUpper().Contains(Daparture_Time.ToUpper())).OrderBy(flight=>flight.price);
            }
            return View(flights.ToList());
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            return View(ause.GetById(1));
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(flight f)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            if (ModelState.IsValid)
            {
                ause.Add(f);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            return View();
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
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
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            return View();
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
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
        public ActionResult DisplayListObject(int id)
        {
            //debut code khawla
            IUserService service = new UserService();
            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();
            //fin code khawla
            var l = ause.GetById(id);
            flight f = ause.GetById(id);
            return View(ause.GetById(1));
        }
    }
}
