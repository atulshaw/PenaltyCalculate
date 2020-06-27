using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Data.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
    where T : class
    {
        protected DbContext Entities;
        protected DbSet<T> DbSet;

        /// <summary>
        /// Initializes a new Instance of Generic Repository With Specified Generic Entity
        /// </summary>
        /// <param name="context">Unit of work object</param>
        protected GenericRepository(IUnitOfWork context)
        {
            Entities = context.getContext();
            DbSet = Entities.Set<T>();
        }
       /// <summary>
       /// Get All
       /// </summary>
       /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }
        
    }
}