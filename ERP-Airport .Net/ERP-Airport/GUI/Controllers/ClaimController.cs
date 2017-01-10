using Airport.Domain.Entities;
using Airport.Service;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GUI.Controllers
{
    public class ClaimController : Controller
    {
        
        //string id = "1";
        IClaimService cls=new ClaimService();
        public ClaimController(IClaimService cls)
        {
            this.cls = cls;

        }

        public ClaimController() { }

        public ActionResult MyClaims()
        {//debut code khawla
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

            var myClaim = cls.MesClaims(User.Identity.GetUserId()).ToList();
            return View(myClaim);

        }

        // GET: Claim
        public ActionResult Index()
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
            var l = cls.GetMany();
            return View(l);
        }

        // GET: Claim/Details/5
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
            claim comm = cls.GetById(id);

            return View(comm);
        }

        // GET: Claim/Create
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

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(claim c)
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
                var MyDateTime = DateTime.Today;
                String MyString;
                MyString = MyDateTime.ToString("yyyy-MM-dd");
                c.editionDate = MyString;
                c.customer_id = User.Identity.GetUserId();
                cls.Add(c);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Claim/Edit/5
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

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {//debut code khawla
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

        // GET: Claim/Delete/5
        public ActionResult Delete(long id, bool? saveChangesError)
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
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            claim comme = cls.GetById(id);
            return View(comme);
        }

        // POST: Claim/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {//debut code khawla
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
                claim comme = cls.GetById(id);
                cls.Delete(comme);

            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    

       
           














    }
        }
