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
    public class ReservationService : Service<reservation>, IReservationService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public ReservationService(): base(ut)
        {
           
           

        }
        public IEnumerable<reservation> GetAReservationByFlight(int flightId)
        {
            return ut.getRepository<reservation>().GetMany(x => x.flight.idFlight == flightId);
        }


        public IEnumerable<reservation> GetMyReservations(string custId)

        {
            var aa = ut.getRepository<reservation>().GetMany(a => a.customer_id.Equals(custId)).ToList();
            return aa;

        }


    }

}
