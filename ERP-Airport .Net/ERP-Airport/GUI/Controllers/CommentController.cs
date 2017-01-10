using Airport.Domain.Entities;
using Airport.Service;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class CommentController : Controller
    {
        //string id = "1"; 
        ICommentService cs=new CommentService();
       
        public CommentController(ICommentService cs)
        {
            this.cs = cs;

        }
        public CommentController() { }

        public ActionResult MyComments() {
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
            var myComments = cs.MesComments(User.Identity.GetUserId()).ToList();
            return View(myComments);

        }
        // GET: Comment
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
            var l = cs.GetMany();
            return View(l);
        }

        // GET: Comment/Details/5
        public ActionResult Details(long id)
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
            comment comm = cs.GetById(id);

            return View(comm);
        }

        // GET: Comment/Create
        public ActionResult Create() { 
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

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(comment c)
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
               
                c.editionDate = DateTime.Today;
                c.customer_id = User.Identity.GetUserId();
                cs.Add(c);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(long id)
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
            comment comm = cs.GetById(id);
            
            return View(comm);

        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(comment comm)
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
                comm.editionDate = DateTime.Today;
                comm.customer_id = User.Identity.GetUserId();
                cs.Update(comm);

                return RedirectToAction("Index");
            }
            else
            {
                return View(comm);
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(long id,bool? saveChangesError)
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
            comment comme = cs.GetById(id);
            return View(comme);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
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
                comment comme = cs.GetById(id);
                cs.Delete(comme);
              
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
