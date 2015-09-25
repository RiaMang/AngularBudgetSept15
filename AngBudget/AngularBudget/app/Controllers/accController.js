(function () {
    var app = angular.module('app');
    app.controller('accCtrl', ['accService', '$stateParams', '$modal', function (accService, $stateParams, $modal) {
        var scope = this;
        scope.id = $stateParams.id;
        scope.Params = {
            HId: 1,
            id: scope.id
        };
        scope.Account = { };
        scope.Accounts = [];

        scope.getAccounts = function () {
            accService.getAccounts(scope.Params).then(function (result) {
                scope.Accounts = result;
                console.log("Accounts: " + scope.Accounts);
            })
            
        };
        scope.getAccounts();

        scope.getAccountDetails = function () {
            accService.getAccountDetails(scope.Params).then(function (result) {
                scope.Account = result;
                console.log("Account : " + scope.Account);
            })
           
        };
        
        scope.open = function (id) {
            console.log("Id in open " + id)
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'AccEditModal.html',
                controller: 'AccModalCtrl as AccMdCtrl',
                size: 'lg',
                resolve: {
                    account: function () {
                        return accService.getAccountDetails({id: id})
                    }
                }
            });

            modalInstance.result.then(function () {
                // Do something after model ok- closed
                console.log('edit account complete');
            }, function () {
                // do something after model is cancel- closed
            });
        };
    }]);
})();