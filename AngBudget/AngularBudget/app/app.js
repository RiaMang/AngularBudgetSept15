

(function () {


    var app = angular.module('app', ['ui.router', 'ui.bootstrap', 'LocalStorageModule','nvd3']);

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
            .state('login', {                   
                url: "/login",                  
                templateUrl: 'login.html',      
                controller: "loginCtrl as login"       
            })
            .state('dashboard', {
                url: "/dashboard",
                templateUrl: 'dashboard.html',
                controller: "homeCtrl as home",
                data: {
                    requireHousehold: true
                }
            })
            .state('accounts', {
                url: "/accounts",
                templateUrl: 'accounts.html',
                controller: 'accCtrl as account'
                
            })
            .state('accounts.create', {
                url: '/create',
                templateUrl: 'accounts-create.html',
                controller: "accCtrl as account"
                
            })
            .state('accounts.edit', {
                url: "/edit/:id",
                templateUrl: 'accounts-edit.html',
                controller: "accCtrl as account",
                //resolve: function ($stateParams) {

                //},
                
                //params: { id: 0 }
            })
            .state('accounts.del', {
                url: "/delete/:id",
                templateUrl: 'accounts-del.html',
                controller: "accCtrl as account"
                //params: { id: 0 }
            })
            .state('transactions', {
                url: "/transactions",
                templateUrl: 'transactions.html',
                //params: { AccId: 0 }
            })
            .state('accTrans', {
                url: "/Account/:AccId/Transactions",
                templateUrl: 'accTrans.html',
                controller: "trCtrl as trans"
            })
            .state('accTrans.create', {
                url: '/Create',
                templateUrl: 'trans-create.html',
                controller: "trCtrl as trans"
            })
            .state('accTrans.edit', {
                url: '/edit/:id',
                templateUrl: 'trans-edit.html',
                controller: "trCtrl as trans"
            })
            .state('accTrans.del', {
                url: '/Delete/:id',
                templateUrl: 'trans-del.html',
                controller: "trCtrl as trans"
            })
            .state('budgetItems', {
                url: '/BudgetItems',
                abstract: true,
                templateUrl: 'budgetItems.html'
            })
            .state('budgetItems.list', {
                url: '/list',
                templateUrl: 'budgetItems.html'
            })
            .state('budgetItems.create', {
                url: '/Create',
                templateUrl: 'budgetItems-create.html'
            })
            .state('budgetItems.edit', {
                url: '/Edit',
                templateUrl: 'budgetItems-edit.html'
            })
            .state('budgetItems.del', {
                url: '/Delete',
                templateUrl: 'budgetItems-del.html'
            })
            .state('budget', {
                url: '/Budget',
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

    //app.run(['authSvc', function (authService) {  // before HouseholdRequired State change redirect.
    //    authService.fillAuthData();
    //}]);

    app.run(['$rootScope', '$state', '$stateParams', 'authSvc', function ($rootScope, $state, $stateParams, authService) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
        authService.fillAuthData();

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            if (toState.data && toState.data.requiresHousehold === true) {
                if (!authService.authentication.isAuth) {
                    $state.go('login');
                }

                if (authService.authentication.householdId == null ||
                    authService.authentication.householdId == "") {
                    console.log('YOU SHALL NOT PASS');
                }

            }
        });
    }]);


})();