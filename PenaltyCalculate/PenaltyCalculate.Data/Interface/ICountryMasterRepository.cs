using PenaltyCalculate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Data.Interface
{
    public interface ICountryMasterRepository
    {
        /// <summary>
        /// Get Country Master List
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        IEnumerable<tblCountryMasterDetails> GetCountryMasterList(string CountyID);

        /// <summary>
        /// Get All Country
        /// </summary>
        /// <returns></returns>
        IEnumerable<tblCountryMasterDetails> GetAllCountry();

    }
}
