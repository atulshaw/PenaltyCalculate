using PenaltyCalculate.Data;
using PenaltyCalculate.Data.Interface;
using PenaltyCalculate.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Service.Implementation
{
    public class PenaltyCalculateService : IPenaltyCalculateService
    {
        protected IPenaltyCalculateRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="repo"></param>
        public PenaltyCalculateService(IPenaltyCalculateRepository repo)
        {
            _repository = repo;
        }
        /// <summary>
        /// Getting Holiday List
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public IEnumerable<tblholiday> GetHolidayList(string CountyID)
        {
            return _repository.GetHolidayList(CountyID);

        }

  
    }
}