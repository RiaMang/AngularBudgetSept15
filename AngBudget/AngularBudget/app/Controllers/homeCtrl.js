(function(){
    var app = angular.module('app');
    app.controller('homeCtrl',['homeSvc',function(homeSvc){
        var scope = this;
        scope.values = [];
        

        scope.options = {
            chart: {
                type: 'multiBarChart',
                height: 450,
                transitionDuration: 500
            }
        }

        scope.getValues = function(){
            homeSvc.getValues().then(function (result) {
                scope.values = result;
            });
        };

        scope.getValues();
    }]);

})();