(function () {
    'use strict';
    
    var controllerId = 'addMember';

    angular.module('app').controller(controllerId,
        ['common', 'repository', '$routeParams', 'logger', '$scope', '$filter', '$location','$upload',  addMember]);

    function addMember(common, repository, $routeParams, logger, $scope, $filter, $location, $upload) {
       
        var vm = this;
        activate();
        var foto;
        vm.saveMember = saveMember;
        vm.clear = clear;
        vm.goBack = goBack;
        vm.uploadComplete = passDataToServer;
        vm.onFileSelect=onFileSelect;
        vm.fileUploadObj = 'Test up';

        function onFileSelect($files) {
            var file = $files[0];
            vm.upload = $upload.upload({
                url: 'api/file/upload',
                data: { fileUploadObj: vm.fileUploadObj },
                file: file
            }).progress(function (evt) {
                console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
            }).success(function (data, status, headers, config) {
                foto = JSON.parse(data);
                vm.tempFoto = foto;
            }).error(function (data, status, headers, config) {
                // file failed to upload
                console.log(data);
            });;
        }

        

        function activate() {
            var promises = [];
            var id = $routeParams.id;
            if (id != 0) {
                vm.title = 'Редактировать служителя';
                promises = [];
            } else {
                vm.title = 'Создать служителя';
            }

            common.activateController(promises, controllerId)
                .then(function () { }, function () { log('Failed'); });
        }

        function getMemberById(id) {
            repository.getMember(id).then(function (data) {
                $scope.$watch('data.start', function () {
                    data.start = $filter('dateTimeLong')(data.start);
                });
                $scope.$watch('data.end', function () {
                    data.end = $filter('dateTimeLong')(data.end);
                });
                vm.e = data;

            }, function (status) {
                logger.logWarning(status, current, controllerId, true);
            });
        }

        function passDataToServer(member) {
            
            vm.member.foto = foto;
            //if (member.id) {
            //    repository.putMember(member).then(function (data) {
            //        success(data);
            //    }, function (data, status) {
            //        error(data);
            //    });
            //} else {
                repository.postMember(member).then(function (data) {
                    success(data);
                }, function (data, status) {
                    error(data);
                });
            //}
        }

        function success(data) {
            $location.path('/events');
            var logSuccess = common.logger.logSuccess;
            logSuccess(data, data, controllerId, true);
        }

        function error(data) {
            vm.errors = data;
        }

        function saveMember(member) {
            member.start = $('#eventStartDate').val();
            passDataToServer(member);
        }

        function goBack() {
            $location.path('/members');
        }

        function clear() {
            vm.e.start = '';
            vm.e.end = '';
            vm.e.title = '';
            vm.e.description = '';
        }
        
    }
})();
