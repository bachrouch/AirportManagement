using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class airline
    {
        public airline()
        {
            this.airplanes = new List<airplane>();
            this.flights = new List<flight>();
            this.users = new List<user>();
        }

        public int idAirline { get; set; }
        public string localAddress { get; set; }
        public string name { get; set; }
        public virtual ICollection<airplane> airplanes { get; set; }
        public virtual ICollection<flight> flights { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
