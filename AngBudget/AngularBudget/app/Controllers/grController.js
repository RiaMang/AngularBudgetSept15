(function () {
    var app = angular.module('app');
    app.controller('gCtrl', ['gsvc', function (gsvc) {
        var scope = this;
        scope.id = {
            HId: 1,
        };
        scope.hh = {
            Id: 0,
            Name: ""
        };
        scope.users = [];

        scope.getGroup = function(){
            gsvc.getGroup(scope.id).then(function (result) {
                scope.hh = result;
                console.log("group: " + scope.hh);
            })
            console.log("group: " + scope.hh);
        };
        scope.getGroup();

        scope.getUsers = function () {
            gsvc.getUsers(scope.id).then(function (result) {
                scope.users = result;
                console.log("users : " + scope.users);
            })
            console.log("users : " + scope.users);
        };
        scope.getUsers();

    }]);
})();