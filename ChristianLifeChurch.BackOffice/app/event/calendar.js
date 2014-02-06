(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'calendar';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['common', 'repository', '$location','$window', calendar]);

    function calendar(common, repository, $location, $window) {
        
        var vm = this;
        vm.title = 'Календарь событий';
        vm.goBack = goBack;
        activate();

        function activate() {
            common.activateController([getAllEvents()], controllerId)
               .then(function () { });
        }

        function getAllEvents() {
            repository.getAllEvents().then(function (data) {
                renderCalendar(data);
            }, function (status) {
                console.log(status);
            });
        }

        function renderCalendar(data) {
            console.log(data);
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                eventColor: '#378006',
                eventBackgroundColor: '#378006',
                defaultDate: Date.now(),
                theme: true,
                lang: 'ru',
                buttonIcons: true, // show the prev/next text
                weekNumbers: true,
                editable: false,
                events: data,
                eventClick: function (calEvent, jsEvent, view) {
                    console.log(calEvent.id);
                    redirectToDetails(calEvent.id);
                }
            });
        }

        function redirectToDetails(id) {
            $window.location.href ='#/events/details/'+id;
        }

        function goBack() {
            $location.path('/events');
        }
     
    }
})();
