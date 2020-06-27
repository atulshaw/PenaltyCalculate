using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PenaltyCalculate.API.Models
{
    public class CalculationEntity
    {
        /// <summary>
        /// CountryID
        /// </summary>
        public string CountryID { get; set; }
        /// <summary>
        /// CheckInDate
        /// </summary>
        public string CheckInDate { get; set; }
        /// <summary>
        /// CheckOutDate
        /// </summary>
        public string CheckOutDate { get; set; }
    }

    public class CalculatedResult
    {
        public string PenaAmount { get; set; }
        public int CalculatedBusinesDays { get; set; }
        public int TotalWorkingDays { get; set; }
        public string PerDayLateFees { get; set; }
    }
}