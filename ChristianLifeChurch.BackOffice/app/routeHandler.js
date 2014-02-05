(function () {
    'use strict';
   
    var serviceId = 'routeHandler';
    
    angular.module('app').factory(serviceId, ['$rootScope', '$location', 'logger', 'common', 'config', routeHandler]);

    function routeHandler($rootScope, $location,logger, common, config) {
        var handleRouteChangeError = false;
        var service = {
            setRouteSettings: setRouteSettings
        };

        return service;

        function setRouteSettings() {
            errorRoutingBehavior();
            applyDocTitle();
        }

        function errorRoutingBehavior () {
            $rootScope.$on('$routeChangeError', function (event, current, previous, rejection) {
                if (handleRouteChangeError) {
                    return;
                }
                handleRouteChangeError = true;
                var msg = 'Такой страницы не существует ' + (current && current.name);
                logger.logWarning(msg,current,serviceId,true);
                $location.path('/');
            });
        }

        function applyDocTitle() {
            $rootScope.$on('$routeChangeSuccess', function (event, current, previos) {
                handleRouteChangeError = false;
                var title = config.docTitle + ':' + (current.title||'');
                $rootScope.title = title;
            });
        }
    }
})();