using PenaltyCalculate.API.Models;
using PenaltyCalculate.Data;
using PenaltyCalculate.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PenaltyCalculate.API.Controllers
{
    [RoutePrefix("api/PenaltyCalculate")]
    [EnableCors("*", "*", "*")]
    public class PenaltyCalculateController : ApiController
    {
        private readonly IPenaltyCalculateService _PenaltyCalculateService;
        private readonly ICountryMasterService _CountryMasterService;
        public PenaltyCalculateController(IPenaltyCalculateService PenaltyCalculateService, ICountryMasterService CountryMasterService)
        {
            _PenaltyCalculateService = PenaltyCalculateService;
            _CountryMasterService = CountryMasterService;
        }

        /// <summary>
        /// To Calculate Penalty Amount
        /// </summary>
        /// <returns></returns>       
        [HttpPost]
        [Route("CalculatePenalty")]
        public async Task<IHttpActionResult> CalculatePenaltyAmount(CalculationEntity param)
        {
            try
            {
                double PenaltYAmount = 0; double LateFees = 1; int lateFineCalculateDays = 0; string Weekends = "";string currency = "";
                //Getting List of holidays based on country id
                var holidayList = _PenaltyCalculateService.GetHolidayList(param.CountryID).ToList();
                //Getting List of country master details
                var countryMasterDetails = _CountryMasterService.GetCountryMasterList(param.CountryID).ToList();
                if (countryMasterDetails.Count > 0)
                {
                    LateFees = Convert.ToDouble(countryMasterDetails.FirstOrDefault().PenaltyFee);
                    lateFineCalculateDays = Convert.ToInt32(countryMasterDetails.FirstOrDefault().PenaltyCalculateDays);
                    Weekends = countryMasterDetails.FirstOrDefault().Weekends;
                    currency = countryMasterDetails.FirstOrDefault().Currency;
                }
                // getting number of business working days
                int DayCount = GetWorkingDays(Convert.ToDateTime(param.CheckOutDate), Convert.ToDateTime(param.CheckInDate), Weekends, holidayList);

                if ((DayCount - lateFineCalculateDays) > 0 && DayCount > lateFineCalculateDays)
                {
                    PenaltYAmount = (DayCount - lateFineCalculateDays) * LateFees;
                }
                var CalValue = new CalculatedResult
                {
                    PenaAmount = currency +" "+ Convert.ToString(PenaltYAmount),
                    CalculatedBusinesDays = DayCount - lateFineCalculateDays,
                    TotalWorkingDays = DayCount,
                    PerDayLateFees = currency + " " + Convert.ToString(LateFees)
                };
                return await Task.FromResult(Json(CalValue));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occurs in fetching the Calculate Penalty Amount ", ex);
            }
        }

        /// <summary>
        /// To Get the Country
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        [Route("GetCountry")]
        public async Task<IHttpActionResult> GetCountry()
        {
            try
            {
                //Getting List of country master details                
                var countryMasterDetails = _CountryMasterService.GetAllCountry().Select(x => new { x.Country, x.CountryID }).ToList();
                return await Task.FromResult(Json(countryMasterDetails));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occurs in fetching the Calculate Penalty Amount ", ex);
            }
        }

        public int GetWorkingDays(DateTime from, DateTime to, string weekends, List<tblholiday> lstHolidays)
        {
            var totalDays = 0;
            var holiday = lstHolidays.Select(x => x.NationalHoliday).ToList();
            for (var date = from; date <= to; date = date.AddDays(1))
            {
                if (weekends.Contains(","))
                {
                    if (date.DayOfWeek.ToString() != Convert.ToString(weekends.Split(',')[0].Trim()) && date.DayOfWeek.ToString() != Convert.ToString(weekends.Split(',')[1].Trim()) && !holiday.Contains(date))
                        totalDays++;
                }
                else
                {
                    if (date.DayOfWeek.ToString() != Convert.ToString(weekends) && !holiday.Contains(date))
                        totalDays++;
                }
            }
            return totalDays;
        }
    }
}
