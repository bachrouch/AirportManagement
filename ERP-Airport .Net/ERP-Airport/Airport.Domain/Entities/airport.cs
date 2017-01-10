using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class airport
    {
        public airport()
        {
            this.flightinfs = new List<flightinf>();
        }

        public int idAirport { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public virtual ICollection<flightinf> flightinfs { get; set; }
    }
}
