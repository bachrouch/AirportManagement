using System;
using System.Collections.Generic;

namespace Airport.Domain.Entities
{
    public partial class employee
    {
        public int id { get; set; }
        public string addressMail { get; set; }
        public string firstName { get; set; }
        public string grade { get; set; }
        public string lastName { get; set; }
        public float salary { get; set; }
        public int idEmployee { get; set; }
        public string state { get; set; }
        public string hireDate { get; set; }
    }
}
