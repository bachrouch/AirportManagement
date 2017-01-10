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
    public class UserService : Service<user>, IUserService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public UserService(): base(ut)
        {
           
           

        }
        public IEnumerable<user> GetAReservationByFlight(string grade)
        {
            return ut.getRepository<user>().GetMany(x => x.grade == grade);
        }





    }

}
