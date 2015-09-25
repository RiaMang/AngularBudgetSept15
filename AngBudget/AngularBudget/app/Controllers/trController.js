
(function () {
    var app = angular.module('app');
    app.controller('trCtrl', ['trService', '$stateParams', function (trService, $stateParams) {
        var scope = this;
        scope.Params = {
            id: $stateParams.id,
            AccId: $stateParams.AccId
        }
        scope.id = $stateParams.id;
        scope.AccId = $stateParams.AccId;
        scope.Hid = {
            HId: 1,
        };
        scope.Account = {
            Id: 0,
            Name: "",
            Balance: 0,
            HouseholdId: 1
        };
        scope.Transaction = {
            Id: 0,


        }
        scope.Transactions = [];

        scope.getTransactions = function () {
            trService.getTransactions(scope.Params).then(function (result) {
                scope.Transactions = result;
                console.log("Transactions: ");
                console.log(scope.Transactions);
            })
            
        };
        console.log('AccId: ' + scope.AccId);
        scope.getTransactions();

        //scope.getUsers = function () {
        //    gsvc.getUsers(scope.id).then(function (result) {
        //        scope.users = result;
        //        console.log("users : " + scope.users);
        //    })
        //    console.log("users : " + scope.users);
        //};
        //scope.getUsers();

    }]);
})();