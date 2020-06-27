using PenaltyCalculate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Data.Interface
{
    public interface IPenaltyCalculateRepository
    {
        /// <summary>
        /// Get Holiday List
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        IEnumerable<tblholiday> GetHolidayList(string CountyID);
               
    }
}
