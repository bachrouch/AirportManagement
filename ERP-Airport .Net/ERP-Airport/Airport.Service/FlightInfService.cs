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
    public class FlightInfService : Service<flightinf>, IFlightInfService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public FlightInfService(): base(ut)
        {
           
           

        }
        public IEnumerable<flightinf> GetFlightInfByType(bool type)
        {
            return ut.getRepository<flightinf>().GetMany(x => x.type == type);
        }

        public List<flightinf> getFlightInfoByFlight(int id)
        {
            return ut.getRepository<flightinf>().GetMany(x => x.idFlight == id).ToList();
        }
    }

}
