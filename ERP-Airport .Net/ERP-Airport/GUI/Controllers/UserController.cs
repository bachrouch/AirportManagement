using Airport.Domain.Entities;
using Airport.Service;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class UserController : Controller
    {
        string id = "1";
        IUserService userv=new UserService();

        public UserController(IUserService userv)
        {
            this.userv = userv;
        }

        public UserController() { }

        // GET: User
        public ActionResult Index()
        {

            var l = userv.GetMany();
            return View(l);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            id = "1";
            user comm = userv.GetById(id);

            return View(comm);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            user comm =userv.GetById(id);

            return View(comm);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(user client)
        {
            if (ModelState.IsValid)

            {
                client.Id = id;
                userv.Update(client);

                return RedirectToAction("Index");
            }
            else
            {
                return View(client);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
