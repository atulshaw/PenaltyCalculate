using PenaltyCalculate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculate.Service.Interface
{
    public interface IPenaltyCalculateService
    {
        IEnumerable<tblholiday> GetHolidayList(string CountyID);
      
    }
}
