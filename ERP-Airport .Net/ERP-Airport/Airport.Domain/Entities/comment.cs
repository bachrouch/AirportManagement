using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class comment
    {
        public int idComment { get; set; }
        public Nullable<System.DateTime> editionDate { get; set; }
        public string text { get; set; }
        public String customer_id { get; set; }
        public virtual user user { get; set; }
    }
}
