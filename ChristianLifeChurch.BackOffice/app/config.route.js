﻿(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'Главная',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Главная'
                    }
                }
            }, {
                url: '/admin',
                config: {
                    title: 'Отправить SMS',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Отправить SMS'
                    }
                }
            },
             {
                 url: '/events',
                 config: {
                     title: 'События',
                     templateUrl: 'app/event/listofevents.html',
                     settings: {
                         nav: 3,
                         content: '<i class="fa fa-calendar"></i> События'
                     }
                 }
             },
               {
                   url: '/events/addeditevent/:id',
                   config: {
                       title: 'События',
                       templateUrl: 'app/event/editevent.html',
                       settings: {}
                   }
               },
               {
                   url: '/events/calendar',
                   config: {
                       title: 'Календарь событий',
                       templateUrl: 'app/event/calendar.html',
                       settings: {}
                   }
               },
               {
                   url: '/events/details/:id',
                   config: {
                       title: 'Календарь событий',
                       templateUrl: 'app/event/details.html',
                       settings: {}
                   }
               },
               {
                   url: '/members',
                   config: {
                       title: 'Служители',
                       templateUrl: 'app/member/listOfMembers.html',
                       settings: {
                           nav: 4,
                           content: '<i class="fa fa-users"></i> Служители'
                       }
                   }
               },
               {
                   url: '/member/addmember/:id',
                   config: {
                       title: 'Служители',
                       templateUrl: 'app/member/addMember.html',
                       settings: {}
                   }
               },
        ];
    }
})();