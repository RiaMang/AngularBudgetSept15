(function () {
    angular.module('app').factory('accService', ['$http', function ($http) {
        var service = {};

        service.getAccounts = function (id) {

            return $http.post('/api/Accounts/GetAccounts', id).then(function (response) {
                return response.data;
            });
        }

        service.getAccountDetails = function (id) {

            return $http.post('/api/Accounts/GetAccountDetails', id).then(function (response) {
                return response.data;
            });
        }

        service.updateAccount = function (account) {

            return $http.post('/api/Accounts/UpdateAccount', account).then(function (response) {
                return response.data;
            });
        }

        return service;

    }])
})();