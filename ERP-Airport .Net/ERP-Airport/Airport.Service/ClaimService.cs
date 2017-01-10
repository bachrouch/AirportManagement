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
    public class ClaimService : Service<claim>, IClaimService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public ClaimService(): base(ut)
        {
           
           

        }
        public IEnumerable<claim> GetClaimByEditionDate(string editionDate)
        {
            return ut.getRepository<claim>().GetMany(x => x.editionDate == editionDate);
        }

        public IEnumerable<claim> MesClaims(string id)
        {
            var mesClaim = ut.getRepository<claim>().GetMany(c => c.customer_id.Equals(id));
            return mesClaim;
        }



    }

}
