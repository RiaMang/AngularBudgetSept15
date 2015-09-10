(function () {
    angular.module('app').factory('bisvc', ['$http', '$q', function ($http, $q) {
        var service = {};

        service.getBudgetItems = function (selected) {
           
            return $http.post('/api/BudgetItems/GetBudgetItems', selected).then(function (response) {
                return response.data;
            });
        }

        return service;

    }])
 })();