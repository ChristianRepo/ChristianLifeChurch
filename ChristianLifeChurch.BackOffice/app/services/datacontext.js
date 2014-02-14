(function () {
    'use strict';

    var serviceId = 'repository';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;
        var $http = common.$http;

        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            getAllEvents: getAllEvents,
            getEvent: getEvent,
            postEvent: postEvent,
            putEvent:putEvent,
            deleteEvent: deleteEvent,
            getAllMembers: getAllMembers,
            postMember: postMember
        };

        return service;

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];
            return $q.when(people);
        }

        function getAllMembers() {
            var deferred = $q.defer();
            $http.get('api/member').success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(status);
            });
            return deferred.promise;
        }

        function postMember(member) {
            var deferred = $q.defer();
            $http.post('api/member/', member).success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(data, status);
            });
            return deferred.promise;
        }

        function getAllEvents() {
            var deferred = $q.defer();
            $http.get('api/event').success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(status);
            });
            return deferred.promise;
        }

        function getEvent(id) {
            var deferred = $q.defer();
            $http.get('api/event/'+id).success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(status);
            });
            return deferred.promise;
        }

        function deleteEvent(id) {
            var deferred = $q.defer();
            $http.delete('api/event/' + id).success(function(data, status, headers, config) {
                deferred.resolve(data);
            }).error(function(data, status, headers, config) {
                deferred.reject(data, status);
            });
            return deferred.promise;
        }

        function postEvent(event) {
            var deferred = $q.defer();
            $http.post('api/event/', event).success(function(data, status, headers, config) {
                deferred.resolve(data);
            }).error(function(data, status, headers, config) {
                deferred.reject(data,status);
            });
            return deferred.promise;
        }

        function putEvent(event) {
            var deferred = $q.defer();
            $http.put('api/event/'+ event.id, event).success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(data, status);
            });
            return deferred.promise;
        }

        
    }
})();