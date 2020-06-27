AnguarModule.service('ApiCall', ['$http', function ($http) {
    var result; 

    // This is used for calling post methods from web api with passing some data to the web api controller
    this.PenaltyCalculate = function (controllerName,obj) {
        result = $http.post(controllerName, obj).success(function (data, status) {
            result = (data);
        }).error(function (msg) {
            alert("Something went wrong");
        });
        return result;
    };

    // This is used for calling get methods from web api to get the country list
    this.GetCountry = function (controllerName) {
        result = $http.get(controllerName).success(function (data, status) {
            result = (data);
        }).error(function (msg) {
            alert("Something went wrong");
        });
        return result;
    };

}]);

