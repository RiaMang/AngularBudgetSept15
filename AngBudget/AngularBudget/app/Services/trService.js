(function () {
    angular.module('app').factory('trService', ['$http', function ($http) {
        var service = {};

       
        service.getTransactions = function (param) {
            
            return $http.post('/api/Transactions/GetTransactions', param).then(function (response) {
                return response.data;
            });
        }

        return service;

    }])
})();