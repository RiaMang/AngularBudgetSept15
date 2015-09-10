

(function () {


    var app = angular.module('app', ['ui.router', 'LocalStorageModule']);

    app.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider

            //.state('index', {

            //    templateUrl: 'index.html'
            //})                                // $state.current.data.displayName
            .state('group', {                   // data: {
                url: "/group",                  //      displayName: 'whatever',
                templateUrl: 'group.html',      //      authorizedRoles: ["Admin", "Moderator"]
                controller: "gCtrl as g"        //      }
            })
            .state('dashboard', {
                templateUrl: 'dashboard.html'
            })
            .state('accounts', {
                templateUrl: 'accounts.html',
                controller: function ($scope) {
                    $scope.Accounts = ['Wells Fargo', 'Allegacy', 'BOA'];
                }
            })
            .state('accounts.create', {
                //url: '/list',
                templateUrl: 'accounts-create.html'
            })
            .state('accounts.edit', {
                templateUrl: 'accounts-edit.html'
            })
            .state('accounts.del', {
                templateUrl: 'accounts-del.html'
            })
            .state('transactions', {
                templateUrl: 'transactions.html'
            })
            .state('accTrans', {
                templateUrl: 'accTrans.html'
            })
            .state('accTrans.create', {
                //url: '/list',
                templateUrl: 'trans-create.html'
            })
            .state('accTrans.edit', {
                templateUrl: 'trans-edit.html'
            })
            .state('accTrans.del', {
                templateUrl: 'trans-del.html'
            })
            .state('budgetItems', {
                templateUrl: 'budgetItems.html'
            })
            .state('budgetItems.create', {
                //url: '/list',
                templateUrl: 'budgetItems-create.html'
            })
            .state('budgetItems.edit', {
                templateUrl: 'budgetItems-edit.html'
            })
            .state('budgetItems.del', {
                templateUrl: 'budgetItems-del.html'
            })
            .state('budget', {
                templateUrl: 'budget.html'
            });

    });

    var serviceBase = 'http://localhost:52726/';
    
    app.constant('ngAuthSettings', {
        apiServiceBaseUri: serviceBase
    });

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorSvc');
    });

    app.run(['authSvc', function (authService) {
        authService.fillAuthData();
    }]);


})();