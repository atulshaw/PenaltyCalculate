//Declaring angular module
var AnguarModule = angular.module('App', []);
//Declaring angular controller
// ApiCall---This is the service name which is in ApiCallService.js file
AnguarModule.controller('AppController', function ($scope, $http, ApiCall) {
    var vm = this;
    var URL = "http://localhost:40001/"
    vm.PerDayLateFees = ''; vm.PenaltyAmount = '0.00'; vm.PenaltycountDays = '--'; vm.TotalBusinessDays = '--'; vm.ReturnedDate = ''; vm.CheckedOutDate = ''; vm.CountryVal = '0',
   
    vm.getselectval = function () {
        vm.PenaltyAmount = '0.00';
        vm.PenaltycountDays = '--';
        vm.TotalBusinessDays = '--';
    }
    init();
    function init() {
        $('.loader').show();
        var result = ApiCall.GetCountry(URL + "api/PenaltyCalculate/GetCountry").success(function (data) {
            vm.Countries = data;
            $('.loader').hide();
        });
    }
    

    $scope.btnPostCall = function () {
        $('.loader').show();
        if (vm.ReturnedDate == '') {
            alert('Please select checked out date');
            $('.loader').hide();
            return;
        }
        else if (vm.CheckedOutDate == '') {
            alert('Please select book returned date');
            $('.loader').hide();
            return;
        }
        else if (vm.CountryVal == '0') {
            alert('Please select country');
            $('.loader').hide();
            return;
        }
        else {
            var CalculationEntity = {
                CountryID: vm.CountryVal,
                CheckInDate: vm.ReturnedDate,
                CheckOutDate: vm.CheckedOutDate
            };
            
            //Call Post method from web api in angular controller using angular service. I am passing string value to the web api through service.
            var result = ApiCall.PenaltyCalculate(URL + "api/PenaltyCalculate/CalculatePenalty", CalculationEntity).success(function (data) {
                $('.loader').hide();
                vm.PenaltyAmount = data.PenaAmount;
                if (data.CalculatedBusinesDays < 0) {
                    vm.PenaltycountDays = '0';
                }
                else {
                    vm.PenaltycountDays = data.CalculatedBusinesDays;
                }
                vm.TotalBusinessDays = data.TotalWorkingDays;
                vm.PerDayLateFees = data.PerDayLateFees;
            });
        }
    };
});


