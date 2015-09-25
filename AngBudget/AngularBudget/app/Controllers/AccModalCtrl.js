angular.module('app').controller('AccModalCtrl', function ($modal, $modalInstance, account, accService) {

    var scope = this;

    scope.account = account;

    scope.ok = function () {
        $modalInstance.close();
    };

    scope.cancel = function () {
        $modalInstance.dismiss();
    };

    scope.Edit = function (id) {
        accService.updateAccount(account).then(function(response){})
        scope.ok();
    };
})