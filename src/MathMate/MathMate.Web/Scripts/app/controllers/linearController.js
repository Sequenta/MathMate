(function () {
    function linearController($scope, $http) {
        var vm = this;
        vm.linearSystem = "";
        vm.display = null;
        vm.solution = null;

        function formatInput(start,lines,end) {
            lines = lines.join('\\\\');
            return start + lines + end;
        }

        MathJax.Hub.Queue(function () {
            vm.display = MathJax.Hub.getAllJax("linearSystem")[0];
            vm.solution = MathJax.Hub.getAllJax("solution")[0];
        });
        
        vm.updateSystem = function () {
            var input = formatInput('\\begin{cases}', vm.linearSystem.split(/\r|\r\n|\n/), '\\end{cases}');
            MathJax.Hub.Queue(["Text", vm.display, input]);
        };

        vm.solve = function() {
            $http.post('/Linear/Solve', { equations: vm.linearSystem.split(/\r|\r\n|\n/) })
                 .success(function(data) {
                    var result = formatInput('\\begin{pmatrix}', data.Data , '\\end{pmatrix}');
                    MathJax.Hub.Queue(["Text", vm.solution, result]);
                })
                 .error(function (data) {
                    alert(data);
                  });
        }
    }
    angular.module('mathMate-app')
        .controller("LinearController", ['$scope', '$http', linearController]);
})();