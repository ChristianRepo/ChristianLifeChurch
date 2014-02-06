(function () {
    'use strict';

    angular.module('common')
        .factory('confirm',['$modal',confirm]);

    function confirm($modal) {
      var service = {
            startConfirm: startConfirm
        };

        return service;

        function startConfirm(title, text) {
            
            var modalInstance = $modal.open({
                templateUrl: '/app/modals/confirm.html',
                controller: ModalInstanceCtrl,
                resolve: {
                    data: function() {
                        return { title: title, text: text};
                    }
                }
            });

            return modalInstance;
               
              
            }
        }

})();

var ModalInstanceCtrl = function($scope, $modalInstance, data) {
    $scope.title = data.title;
    $scope.text = data.text;

    $scope.ok = function() {
        $modalInstance.close();
    };

    $scope.cancel = function() {
        $modalInstance.dismiss('cancel');
    };
};
