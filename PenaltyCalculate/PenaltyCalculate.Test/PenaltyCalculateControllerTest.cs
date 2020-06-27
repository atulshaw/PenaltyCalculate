using Microsoft.VisualStudio.TestTools.UnitTesting;
using PenaltyCalculate.API.Controllers;
using PenaltyCalculate.API.Models;
using PenaltyCalculate.Data;
using PenaltyCalculate.Data.Common;
using PenaltyCalculate.Data.Implementation;
using PenaltyCalculate.Service.Implementation;
using System.Data.Common;
using System.Threading.Tasks;

namespace PenaltyCalculate.Test
{
    [TestClass]
    public class PenaltyCalculateControllerTest
    {
        private DbConnection _connection;
        private TestContext _testDbContext;
        private UnitOfWork _testUnitOfWork;
        private PenaltyCalculateService _PenaltyCalculateService;
        private PenaltyCalculateRepository _PenaltyCalculateRepository;
        private CountryMasterService _CountryMasterService;
        private CountryMasterRepository _CountryMasterRepository;
        private PenaltyCalculateController _controller = null;
        tblholiday tbl = new tblholiday();

        /// <summary>
        /// Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _connection = Effort.DbConnectionFactory.CreateTransient();
            _testDbContext = new TestContext();
            _testUnitOfWork = new UnitOfWork(_testDbContext);
            _PenaltyCalculateRepository = new PenaltyCalculateRepository(_testUnitOfWork);
            _PenaltyCalculateService = new PenaltyCalculateService(_PenaltyCalculateRepository);
            _CountryMasterRepository = new CountryMasterRepository(_testUnitOfWork);
            _CountryMasterService = new CountryMasterService(_CountryMasterRepository);
            _controller = new PenaltyCalculateController(_PenaltyCalculateService, _CountryMasterService);
        }

        /// <summary>
        /// GetCalculateAmount_CalculateAmount_Test for Dubai
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetCalculateAmount_CalculateAmount_For_Dubai_Test()
        {
            CalculationEntity objCal = new CalculationEntity();
            objCal.CheckInDate = "06/01/2020";
            objCal.CheckOutDate = "06/30/2020";
            objCal.CountryID = "DB";
            var result = await _controller.CalculatePenaltyAmount(objCal);
            Assert.IsNotNull(result);

        }

        /// <summary>
        /// GetCalculateAmount_CalculateAmount_For_US_Test
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetCalculateAmount_CalculateAmount_For_US_Test()
        {
            CalculationEntity objCal = new CalculationEntity();
            objCal.CheckInDate = "06/01/2020";
            objCal.CheckOutDate = "06/30/2020";
            objCal.CountryID = "US";
            var result = await _controller.CalculatePenaltyAmount(objCal);
            Assert.IsNotNull(result);
        }


        /// <summary>
        /// Get Calculate Amount Calculate Amount For Inida Test
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetCalculateAmount_CalculateAmount_For_IN_Test()
        {
            CalculationEntity objCal = new CalculationEntity();
            objCal.CheckInDate = "06/01/2020";
            objCal.CheckOutDate = "06/30/2020";
            objCal.CountryID = "IN";
            var result = await _controller.CalculatePenaltyAmount(objCal);
            Assert.IsNotNull(result);
        }
    }
}
