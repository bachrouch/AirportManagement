using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class stopover
    {
        public int idStopOver { get; set; }
        public Nullable<System.DateTime> arrivalTime { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public Nullable<int> flight_idFlight { get; set; }
        public virtual flight flight { get; set; }
    }
}
