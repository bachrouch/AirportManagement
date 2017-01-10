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
    public class AirportService : Service<airport>, IAirportService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public AirportService(): base(ut)
        {
           
           

        }
        public IEnumerable<airport> GetAirportByCity(string city)
        {
            return ut.getRepository<airport>().GetMany(x => x.city == city);
        }





    }

}
