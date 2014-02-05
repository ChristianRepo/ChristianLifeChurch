(function () {
    'use strict';

    angular.module('app').filter('textSubstring', function () {
        return function (str) {
            if (str.length < 30)
                return str;
            else {
                return str.substring(0, 30) + '...';
            }
            
        };
    });
})();