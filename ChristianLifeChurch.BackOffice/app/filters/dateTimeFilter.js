(function() {
    'use strict';

    var module = angular.module('app');

    module.filter('dateTimeLongRus', function () {
        return function(date) {
           return moment(date).format('LLL');
        };
    });

    module.filter('dateTimeLong', function () {
        return function (date) {
            if (!date) {
                return '';
            }
            return moment(date).format("DD.MM.YYYY HH:mm");
        };
    });
})();