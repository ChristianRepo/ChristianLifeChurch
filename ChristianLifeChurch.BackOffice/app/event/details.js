(function () {
    'use strict';
  
    var controllerId = 'details';

    angular.module('app').controller(controllerId, ['$scope', '$filter', 'common', 'repository', '$routeParams', '$window', details]);

    function details($scope, $filter, common, repository, $routeParams, $window) {
        var vm = this;
        vm.goBack = goBack;
        
        activate();

        function activate() {
            var id = $routeParams.id;
            common.activateController([getEventById(id)], controllerId)
                .then(function () {  });
        }

        function goBack() {
            $window.history.back();
        }

        function getEventById(id) {
            repository.getEvent(id).then(function (data) {
                $scope.$watch('data.start', function () {
                    data.start = $filter('dateTimeLongRus')(data.start);
                });
                $scope.$watch('data.end', function () {
                    data.end = $filter('dateTimeLongRus')(data.end);
                });
                vm.title = data.name;
                vm.e = data;

            }, function (status) {
                logger.logWarning(status, current, controllerId, true);
            });
        }
    
    }
})();
