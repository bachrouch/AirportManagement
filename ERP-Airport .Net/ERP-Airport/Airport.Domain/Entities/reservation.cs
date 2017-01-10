using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class reservation
    {
        public int id { get; set; }
        public string arrivalDate { get; set; }
        public string departureDate { get; set; }
        public Nullable<int> reservationState { get; set; }
        public String customer_id { get; set; }
        public Nullable<int> flight_idFlight { get; set; }
        public virtual flight flight { get; set; }
        public virtual user user { get; set; }
    }
}
