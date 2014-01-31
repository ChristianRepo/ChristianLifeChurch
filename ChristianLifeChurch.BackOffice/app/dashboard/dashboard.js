(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'repository', dashboard]);

    function dashboard(common, repository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Церковь Христианская жизнь',
            description: 'Церковь Христианская жизнь тестовый проект.'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.title = 'Церковь Христианская жизнь';

        activate();

        function activate() {
            var promises = [getMessageCount(), getPeople()];
            common.activateController(promises, controllerId)
                .then(function () { log('Главная страница'); });
        }

        function getMessageCount() {
            return repository.getMessageCount().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getPeople() {
            return repository.getPeople().then(function (data) {
                return vm.people = data;
            });
        }
    }
})();