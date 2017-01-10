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
    public class FlightService : Service<flight>, IFlightService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public FlightService(): base(ut)
        {
        }

        public List<flight> getAllFlights()
        {
            return ut.getRepository<flight>().GetMany().ToList();
        }

        public List<flight> getAllFlightsByDestinationAndStartTime(string destination, string startTime)
        {
            return ut.getRepository<flight>().GetMany(x => x.destination.ToUpper().Contains(destination.ToUpper())).ToList();
        }

        public IEnumerable<flight> GetFlightByLocalDestination(string destination)
        {
            return ut.getRepository<flight>().GetMany(x => x.destination == destination);
        }





    }

}
