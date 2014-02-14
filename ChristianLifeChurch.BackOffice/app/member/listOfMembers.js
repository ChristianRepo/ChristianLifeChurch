(function () {
    'use strict';

    var controllerId = 'listOfMembers';
   
    angular.module('app').controller(controllerId,
        ['common', 'repository', '$location', listOfMembers]);

    function listOfMembers(common, repository, $location) {
        var vm = this;
        activate();

        vm.title = 'Список служителей';

        function activate() {
            vm.editMember = editMember;
            vm.addMember = addMember;
            vm.deleteMember = deleteMember;
            var promises = [getAllMembers()];
            common.activateController(promises, controllerId)
                .then(function () { });
        }

        function addMember() {
            $location.path('/member/addmember/0');
        }

        function editMember(member) {
            $location.path('/member/addmember/' + member.id);
        }

        function deleteMember(member) {
            var modalInstance = common.confirm.startConfirm('Удаление служителя', 'Вы действительно хотите удалить служителя?');

            modalInstance.result.then(function () {
                repository.deletemember(member.id).then(function (data) {
                    getAllMembers();
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

        function getAllMembers() {
            repository.getAllMembers().then(function (data) {
                vm.allMemberCount = data.length;
                vm.memberList = data;
            }, function (status) {
                console.log(status);
            });
        }
       
    }
})();
