using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class claim
    {
        public int idClaim { get; set; }
        public string editionDate { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public String customer_id { get; set; }
        public virtual user user { get; set; }
    }
}
