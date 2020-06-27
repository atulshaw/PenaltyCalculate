using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Data.Common
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
    }
}