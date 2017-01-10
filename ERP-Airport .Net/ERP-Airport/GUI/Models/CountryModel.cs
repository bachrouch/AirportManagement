using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GUI.Models
{
    public class CountryModel
    {
        public string CountryTitle { get; set; }
        public string VisteursTitle { get; set; }
        public Country CountrytData { get; set; }
    }
    public class Country
    {
     
        public string CountryName { get; set; }
        public string Visiteurs { get; set; }
        public Country(string CountryName) { this.CountryName = CountryName; }
        public Country() { }
    }
}