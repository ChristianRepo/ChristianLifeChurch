(function () {
    'use strict';
   
    var controllerId = 'editevent';

    angular.module('app').controller(controllerId,
    [
        'common', 'repository', '$routeParams', 'logger', '$scope', '$filter','$location', editEvent]);

    function editEvent(common, repository, $routeParams, logger, $scope, $filter, $location) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        
        var vm = this;
        activate();
        vm.saveEvent = saveEvent;
        vm.clear = clear;
        vm.goBack = goBack;

        function activate() {
            var promises = [];
            var id = $routeParams.id;
            if (id != 0) {
                vm.title = 'Редактировать событие';
                promises = [getEventById(id)];
            } else {
                vm.title = 'Создать событие';
            }

            common.activateController(promises, controllerId)
                .then(function () { }, function () { log('Failed'); });
        }

        function getEventById(id) {
            repository.getEvent(id).then(function (data) {
                $scope.$watch('data.start', function () {
                    data.start = $filter('dateTimeLong')(data.start);
                });
                $scope.$watch('data.end', function () {
                    data.end = $filter('dateTimeLong')(data.end);
                });
                vm.e = data;
               
            }, function(status) {
                logger.logWarning(status, current, controllerId, true);
            });
        }

        function passDataToServer(event) {
            console.log(event);
            if (event.id) {
                repository.putEvent(event).then(function (data) {
                    success(data);
                }, function (data, status) {
                    error(data);
                });
            } else {
                repository.postEvent(event).then(function (data) {
                    success(data);
                }, function (data, status) {
                    error(data);
                });
            }
        }

        function success(data) {
            $location.path('/events');
            var logSuccess = common.logger.logSuccess;
            logSuccess(data, data, controllerId, true);
        }

        function error(data) {
            vm.errors = data;
        }

        function saveEvent(event) {
           
            event.start = $('#eventStartDate').val();
            event.end = $('#eventEndDate').val();
            passDataToServer(event);
        }

        function goBack() {
            $location.path('/events');
        }

        function clear() {
            vm.e.start = '';
            vm.e.end = '';
            vm.e.title = '';
            vm.e.description = '';
        }

        
    }
})();
