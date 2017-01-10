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
    public class CommentService : Service<comment>, ICommentService
    {
       
       
        private static IDatabaseFactory dbf =  new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        //public ProductService(IUnitOfWork ut)
        //    : base(ut)
        //{
        //    this.ut = ut;

        //}
        public CommentService(): base(ut)
        {
           
           

        }
        public IEnumerable<comment> GetCommentByEditionDate(DateTime editionDate)
        {
            return ut.getRepository<comment>().GetMany(x => x.editionDate == editionDate);
        }


        public IEnumerable<comment> MesComments(string id)
        {
            var mesComments = ut.getRepository<comment>().GetMany(c => c.customer_id.Equals(id));
            return mesComments;
        }


    }

}
