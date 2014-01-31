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
                     templateUrl: 'app/event/event.html',
                     settings: {
                         nav: 3,
                         content: '<i class="fa fa-lock"></i> События'
                     }
                 }
             }
        ];
    }
})();