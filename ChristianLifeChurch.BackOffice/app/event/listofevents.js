(function () {
    'use strict';
    var controllerId = 'listofevents';

    angular.module('app').controller(controllerId, ['common', 'repository', '$location', eventcontroller]);

    function eventcontroller(common, repository, $location) {
        var vm = this;
        activate();

        function activate() {
            vm.title = 'Список событий';
            vm.editEvent = editEvent;
            vm.addNewEvent = addNewEvent;
            vm.deleteEvent = deleteEvent;
            var promises = [getEventsCount(), getAllEvents()];
            common.activateController(promises, controllerId)
                .then(function () {  });
            
        }

        function addNewEvent() {
            $location.path('/events/addeditevent/0');
        }

        function editEvent(event) {
            $location.path('/events/addeditevent/' + event.id);
        }

        function deleteEvent(event) {
            repository.deleteEvent(event.id).then(function (data) {
                getEventsCount();
                getAllEvents();
                var logSuccess = common.logger.logSuccess;
                logSuccess(data, data, controllerId, true);
            }, function (data, status) {
                var msg = data;
                var logError = common.logger.logError;
                logError(msg, data, controllerId, true);
            });
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
