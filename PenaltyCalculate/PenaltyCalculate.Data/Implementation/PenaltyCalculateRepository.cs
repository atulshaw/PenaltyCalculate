using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using PenaltyCalculate.Data;
using PenaltyCalculate.Data.Common;
using PenaltyCalculate.Data.Interface;

namespace PenaltyCalculate.Data.Implementation
{
    public class PenaltyCalculateRepository : GenericRepository<tblholiday>, IPenaltyCalculateRepository
    {
        
        public PenaltyCalculateRepository(IUnitOfWork context)
            : base(context)
        {
          
        }     
        /// <summary>
        /// Getting All the Holiday List
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public IEnumerable<tblholiday> GetHolidayList(string CountyID)
        {            
           return GetAll().AsQueryable().Where(x => x.CountryID == CountyID);
        }
      
    }
}