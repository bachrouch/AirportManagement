using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class airplane
    {
        public int idAirplane { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public int idTrack { get; set; }
        public int number { get; set; }
        public bool state { get; set; }
        public Nullable<int> airline_idAirline { get; set; }
        public int numberTrack { get; set; }
        public virtual airline airline { get; set; }
    }
}
