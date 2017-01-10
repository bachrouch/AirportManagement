using Airport.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Domain.Entities;
using Airport.Data;
using Service.Pattern;

namespace Airport.Service
{
    public class EmployeeService : Service<employee>, IEmployeeService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public EmployeeService(): base(ut)
        {
           
           

        }
        public IEnumerable<employee> GetEmployeeByLocalAddress(string state)
        {
            return ut.getRepository<employee>().GetMany(x => x.state== state);
        }





    }

}
