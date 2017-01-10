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
    public class AirplaneService : Service<airplane>, IAirplaneService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public AirplaneService(): base(ut)
        {
           
           

        }
        public IEnumerable<airplane> GetAirplaneByAirline(string airlineName)
        {
            return ut.getRepository<airplane>().GetMany(x => x.airline.name== airlineName);
        }





    }

}
