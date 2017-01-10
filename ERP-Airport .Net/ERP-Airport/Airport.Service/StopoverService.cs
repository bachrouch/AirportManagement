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
    public class StopoverService : Service<stopover>, IStopoverService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public StopoverService(): base(ut)
        {
           
           

        }
        public IEnumerable<stopover> GetAReservationByFlight(int flightId)
        {
            return ut.getRepository<stopover>().GetMany(x => x.flight.idFlight == flightId);
        }





    }

}
