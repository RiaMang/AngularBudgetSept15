(function(){
var app = angular.module('app');
app.factory('homeSvc',['$http',function($http){
    var service = {};

    service.getValues = function () {
        return $http.post('/api/BudgetItems/GetValues').then(function (response) {
            return response.data;
        });
    };

    return service;
}]);
})();