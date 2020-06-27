using PenaltyCalculate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Service.Interface
{
    public interface ICountryMasterService
    {
        IEnumerable<tblCountryMasterDetails> GetCountryMasterList(string CountyID);
        IEnumerable<tblCountryMasterDetails> GetAllCountry();

    }
}
