
using Airport.Service;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
   
    
    public class HomeController : Controller
    {
        public HomeController(){ }
        AirportService airS=new AirportService();
        CommentService CommentS=new CommentService();
        ReservationService ResS=new ReservationService();
        FlightInfService flightIS=new FlightInfService();
        FlightService Fs=new FlightService();
        public HomeController(AirportService airS, CommentService CommentS, ReservationService ResS , FlightInfService flightIS,FlightService Fs)
        {
            this.airS = airS;
            this.ResS = ResS;
            this.CommentS = CommentS;
            this.Fs = Fs;
            this.flightIS = flightIS;
        }
        public ActionResult Index()
        {
            CountryModel objProductModel = new CountryModel();
            objProductModel.CountrytData = new Country();
            objProductModel.CountrytData = GetChartData();
            objProductModel.CountryTitle = "Country";
            objProductModel.VisteursTitle = "Visteurs";
            return View(objProductModel);

        }
        /// <summary>
        /// Code to get the data which we will pass to chart
        /// </summary>
        /// <returns></returns>
        public Country GetChartData()
        {
            Country objproduct = new Country();
           
            var listAirports = airS.GetMany().ToList();
            var listReservation = ResS.GetMany().ToList();
            var listInfoFlight = flightIS.GetMany().ToList();
            var listFlight = Fs.GetMany().ToList();
            var query= from flight in listFlight
                     join resr in listReservation on flight.idFlight equals resr.flight_idFlight
                       join FlightInf in listInfoFlight on flight.idFlight equals FlightInf.idFlight
                     join air in listAirports on FlightInf.idFlight equals air.idAirport
                       group air by air.country into a
                       select new { CountryName= a.Key,
                                  Visiteurs =a.Count()}
                     ;
               {
             //  airports=airports.Where((airport=>airport.idAirport)==(flight=>flight.))
              }
           // var query = from air in listAirports select new { CountryName = air.country };
            /*Get the data from databse and prepare the chart record data in string form.*/
            int i = 0;
            String[] listCountry = new String[query.ToList().Capacity];
            String[] listVisiters = new String[query.ToList().Capacity];
            foreach (var q in query.ToList())
            {
                //Country c = new Country(q.CountryName);
                listCountry [i] = q.CountryName;
                listVisiters[i] = q.Visiteurs.ToString();
                //objproduct.CountryName = q.CountryName;
                i = i + 1;
            }
           string countrys = "";
            string visituers = "";
            for (int c = 0; c < listCountry.Length-1; c++)
            {
                countrys += listCountry[c]+",";
                visituers += listVisiters[c] + ",";
            }
            countrys += listCountry[listCountry.Length-1];
            visituers += listVisiters[listVisiters.Length - 1];
            objproduct.CountryName = countrys;
            objproduct.Visiteurs = visituers;
            return objproduct;
        }


        public ActionResult About()
        {
            var listComments = CommentS.GetMany().ToList();
            var comments = from comment in listComments select comment;
            ViewBag.Message = "Your application description page.";

            return View(comments.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}