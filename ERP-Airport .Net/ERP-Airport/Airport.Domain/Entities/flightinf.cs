using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class flightinf
    {
        public int idAirport { get; set; }
        public int idFlight { get; set; }
        public bool type { get; set; }
        public virtual airport airport { get; set; }
        public virtual flight flight { get; set; }
    }
}
