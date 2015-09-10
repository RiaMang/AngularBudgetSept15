(function () {
    var app = angular.module('app');
    app.controller('biCtrl', ['bisvc', function (svc) {
        var scope = this;
        scope.budgetItems = [];
        scope.id = {
            HId: 6,
        };
        scope.getBudgetItems = function () {
            svc.getBudgetItems(scope.id).then(function (result) {
                scope.budgetItems = result;
                console.log("budget items: "+scope.budgetItems);
            })
        }
        scope.getBudgetItems();

    }]);
})();