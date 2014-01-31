(function () {
    'use strict';
    var controllerId = 'eventController';

    angular.module('app').controller(controllerId, ['common', 'repository', eventcontroller]);

    function eventcontroller(common, repository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var vm = this;
        activate();

        function activate() {
            vm.title = 'Список событий';
            var promises = [getEventsCount(), getAllEvents()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Event View'); });
            
        }

        function getEventsCount() {
            repository.getAllEvents().then(function (data) {
                console.log(data.length);
            }, function (status) {
                console.log(status);
            });
        }

        function getAllEvents() {
            repository.getAllEvents().then(function (data) {
                vm.eventList = data;
            }, function (status) {
                console.log(status);
            });
        }
   
    }
})();
