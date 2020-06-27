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
    public class CountryMasterService : ICountryMasterService
    {
        protected ICountryMasterRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="repo"></param>
        public CountryMasterService(ICountryMasterRepository repo)
        {
            _repository = repo;
        }
        /// <summary>
        /// Get Country Master List
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public IEnumerable<tblCountryMasterDetails> GetCountryMasterList(string CountyID)
        {
            return _repository.GetCountryMasterList(CountyID);

        }

        /// <summary>
        /// Get All Country
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblCountryMasterDetails> GetAllCountry()
        {
            return _repository.GetAllCountry();
        }


    }
}