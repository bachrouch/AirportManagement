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
    public class AirlineService : Service<airline>, IAirlineService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public AirlineService(): base(ut)
        {
           
           

        }
        public IEnumerable<airline> GetAirlineByLocalAddress(string localAddress)
        {
            return ut.getRepository<airline>().GetMany(x => x.localAddress == localAddress);
        }





    }

}
