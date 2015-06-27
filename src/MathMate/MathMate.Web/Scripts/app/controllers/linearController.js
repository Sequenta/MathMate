(function () {
    function linearController($scope) {
        var vm = this;
        vm.linearSystem = "";
        vm.display = null;

        function formatInput() {
            var start = '\\begin{cases}';
            var end = '\\end{cases}';
            return start + vm.linearSystem + end;
        }

        MathJax.Hub.Queue(function () {
            vm.display = MathJax.Hub.getAllJax("linearSystem")[0];
        });
        
        vm.updateSystem = function () {
            var input = formatInput();
            MathJax.Hub.Queue(["Text", vm.display, input]);
        };
    }
    angular.module('mathMate-app')
        .controller("LinearController", ['$scope', linearController]);
})();