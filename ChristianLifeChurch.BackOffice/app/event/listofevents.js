(function () {
    'use strict';
    var controllerId = 'listofevents';

    angular.module('app').controller(controllerId, ['common', 'repository', '$location', eventcontroller]);

    function eventcontroller(common, repository, $location) {
        var vm = this;
        var date = Date.now();
        activate();

        function activate() {
            vm.title = 'Список событий';
            vm.editEvent = editEvent;
            vm.addNewEvent = addNewEvent;
            vm.deleteEvent = deleteEvent;
            vm.goToCalendar = goToCalendar;
            vm.goToDetails = goToDetails;
            var promises = [getAllEvents()];
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
            var modalInstance = common.confirm.startConfirm('Удаление события', 'Вы действительно хотите удалить событие?');

            modalInstance.result.then(function () {
                repository.deleteEvent(event.id).then(function (data) {
                    getAllEvents();
                    var logSuccess = common.logger.logSuccess;
                    logSuccess(data, data, controllerId, true);
                }, function (data, status) {
                    var msg = data;
                    var logError = common.logger.logError;
                    logError(msg, data, controllerId, true);
                });
            }, function () {
                return;
            });
            
            
        }
       
        function getAllEvents() {
            repository.getAllEvents().then(function (data) {

                var allEventsCount = data.length;
                var activeEventCount = $.grep(data, function (v) {
                    return Date.parse(v.start)> date;
                }).length;

                vm.title = 'Список событий ' + activeEventCount + '/' + allEventsCount;
                vm.eventList = data;
            }, function (status) {
                console.log(status);
            });
        }

        function goToCalendar() {
            $location.path('/events/calendar');
        }

        function goToDetails(id) {
            $location.path('/events/details/'+id);
        }
   
    }
})();
