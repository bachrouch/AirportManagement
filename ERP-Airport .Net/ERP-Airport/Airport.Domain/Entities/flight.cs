using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class flight
    {
        public flight()
        {
            this.flightinfs = new List<flightinf>();
            this.reservations = new List<reservation>();
            this.stopovers = new List<stopover>();
        }

        public int idFlight { get; set; }
        public string arrivalTime { get; set; }
        public string classType { get; set; }
        public string flightState { get; set; }
        public float price { get; set; }
        public string startTime { get; set; }
        public Nullable<int> airline_idAirline { get; set; }
        public string destination { get; set; }
        public string arrivalCity { get; set; }
        public virtual airline airline { get; set; }
        public virtual ICollection<flightinf> flightinfs { get; set; }
        public virtual ICollection<reservation> reservations { get; set; }
        public virtual ICollection<stopover> stopovers { get; set; }
    }
}
