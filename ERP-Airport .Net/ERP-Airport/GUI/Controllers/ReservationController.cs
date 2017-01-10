using Airport.Domain.Entities;
using Airport.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ReservationController : Controller
    {
        IReservationService ause = new ReservationService();
       // string idCust = "1";
        public ReservationController() { }
        public ReservationController(IReservationService ause)
        {
            this.ause = ause;
        }
        // GET: Reservation
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
            var r = ause.GetMyReservations(User.Identity.GetUserId());
            return View(r);
        }

        // GET: Reservation/Details/5
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
            reservation res = ause.GetById(id);
            return View(res);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        { //debut code khawla
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

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(reservation r)
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
            
                int id = int.Parse(this.RouteData.Values["id"].ToString());
                r.reservationState = 1;
                r.flight_idFlight = 1;
                ause.Add(r);
                return RedirectToAction("Index");
           
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        { //debut code khawla
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
            reservation res = ause.GetById(id);
            return View(res);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(reservation res)
        { //debut code khawla
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
           
                ause.Update(res);

                return RedirectToAction("Index");
        


        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        { //debut code khawla
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
        private String randomchar()
        {
            String alphabet = "0123456789ABCDE";
            int N = alphabet.Length;

            Random r = new Random();
            String text = "";
            for (int i = 0; i < 10; i++)
            {
                text += (alphabet.ElementAt(r.Next(N)));
            }
            return text;
        }
        public ActionResult PDF(int id)
        { //debut code khawla
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
            reservation res = ause.GetById(id);
            var x = randomchar();

            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\users\\esprit\\Desktop\\PiDev.NET" + x + ".pdf", FileMode.Create));

            doc.Open();
            Paragraph p = new Paragraph("reseravation Details");

            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);

            // Image img = Image.GetInstance("C:\\Users\\SQLsvc\\Pictures\\logo.png");
            //img.Alignment = Element.ALIGN_RIGHT;
            //doc.Add(img);


            p = new Paragraph("Arrival date: " + res.arrivalDate);


            // p.Alignment = Element.ALIGN_JUSTIFIED;

            doc.Add(p);
            p = new Paragraph("Departure date : " + res.departureDate);
            //  p.Alignment = Element.ALIGN_LEFT;
            doc.Add(p);


            p = new Paragraph("Destination : " + res.flight.destination);
            //  p.Alignment = Element.ANCHOR;
            doc.Add(p);

            p = new Paragraph("Price : " + res.flight.price+"$");
            //  p.Alignment = Element.ANCHOR;
            doc.Add(p);
            p = new Paragraph("Airline : " + res.flight.airline.name);
            //  p.Alignment = Element.ANCHOR;
            doc.Add(p);
        
            doc.Close();

            System.Diagnostics.Process.Start("C:\\users\\esprit\\Desktop\\PiDev.NET" + x + ".pdf");
            //return (Content("<script language='javascript' type='text/javascript'>alert('Download Successfull');</script>"));

            return RedirectToAction("Index");
        }

    }
}
