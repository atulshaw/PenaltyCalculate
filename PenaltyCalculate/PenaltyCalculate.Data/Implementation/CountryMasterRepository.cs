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
    public class CountryMasterRepository : GenericRepository<tblCountryMasterDetails>, ICountryMasterRepository
    {
        
        public CountryMasterRepository(IUnitOfWork context)
            : base(context)
        {
          
        }
        /// <summary>
        /// Getting Country master list
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public IEnumerable<tblCountryMasterDetails> GetCountryMasterList(string CountyID)
        {            
           return GetAll().AsQueryable().Where(x => x.CountryID == CountyID);
        }

        /// <summary>
        /// Get All Country
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblCountryMasterDetails> GetAllCountry()
        {
            return GetAll().AsQueryable().OrderBy(x => x.Country);
        }

    }
}