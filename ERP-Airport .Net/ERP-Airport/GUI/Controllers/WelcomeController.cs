using Airport.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Airport.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace GUI.Controllers
{
    public class WelcomeController : Controller
    {

        IUserService service = new UserService();

        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {

            user u = service.GetById(User.Identity.GetUserId());
            string firstName = u.firstName;
            string lastName = u.lastName;
            string email = u.Email;
            ViewBag.userFirstName = firstName;
            ViewBag.userLastName = lastName;
            ViewBag.userMail = email;
            ViewBag.sexe = u.sexe.ToLower();

            return View();

        }
    }
}