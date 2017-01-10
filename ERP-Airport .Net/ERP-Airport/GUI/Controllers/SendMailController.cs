using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;
using GUI.Models;
using Airport.Service;
using Airport.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace GUI.Controllers
{
    public class SendMailController : Controller
    {
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(MailModel objModelMail, HttpPostedFileBase fileUploader)
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
            if (ModelState.IsValid)
            {
                string from = "mariemjribi123@gmail.com"; //example:- sourabh9303@gmail.com
                using (MailMessage mail = new MailMessage("mariemjribi123@gmail.com", objModelMail.To))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential("mariemjribi123@gmail.com", "52371006");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Index", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }
    }
}