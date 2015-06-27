(function () {
    function linearController($scope, $http) {
        var vm = this;
        vm.linearSystem = "";
        vm.display = null;
        vm.solution = null;

        function formatInput() {
            var start = '\\begin{cases}';
            var end = '\\end{cases}';
            var lines = vm.linearSystem.split(/\r|\r\n|\n/).join('\\\\');
            return start + lines + end;
        }

        MathJax.Hub.Queue(function () {
            vm.display = MathJax.Hub.getAllJax("linearSystem")[0];
            vm.solution = MathJax.Hub.getAllJax("solution")[0];
        });
        
        vm.updateSystem = function () {
            var input = formatInput();
            MathJax.Hub.Queue(["Text", vm.display, input]);
        };

        vm.solve = function() {
            $http.post('/Linear/Solve', { equations: vm.linearSystem.split(/\r|\r\n|\n/) })
                 .success(function(data) {
                    alert(data);
                  })
                 .error(function (data) {
                    alert(data);
                  });
        }
    }
    angular.module('mathMate-app')
        .controller("LinearController", ['$scope', '$http', linearController]);
})();