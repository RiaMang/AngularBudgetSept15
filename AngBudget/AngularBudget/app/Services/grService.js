(function () {
    angular.module('app').factory('gsvc', ['$http', '$q', function ($http, $q) {
        var service = {};

        service.getGroup = function (id) {

            return $http.post('/api/Group/GetGroup', id).then(function (response) {
                return response.data;
            });
        }

        service.getUsers = function (id) {

            return $http.post('/api/Group/GetUsers', id).then(function (response) {
                return response.data[0];
            });
        }

        return service;

    }])
})();