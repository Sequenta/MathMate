(function () {
    function linearController($scope, $http) {
        var vm = this;
        vm.linearSystem = "";
        vm.display = null;
        vm.solution = null;
        vm.isProcessing = false;

        function formatInput(start,lines,end) {
            lines = lines.join('\\\\');
            return start + lines + end;
        }

        function getCoefficients() {
            var str = vm.linearSystem;
            var coefficients = [];
            for (var i = 0; i < str.length; i++) {
                if (coefficients.indexOf(str[i]) == -1 && str[i].match('[a-zA-Z]')) {
                    coefficients.push(str[i]);
                }
            }
            return coefficients;
        }

        function formatSolution(solutionData) {
            var results = [];
            var coefficients = getCoefficients();
            for (var i = 0; i < solutionData.length; i++) {
                results.push(coefficients[i] + '=' + solutionData[i]);
            }
            return results;
        }

        MathJax.Hub.Queue(function () {
            vm.display = MathJax.Hub.getAllJax("linearSystem")[0];
            vm.solution = MathJax.Hub.getAllJax("solution")[0];
        });
        
        vm.updateSystem = function () {
            var input = formatInput('\\begin{cases}', vm.linearSystem.split(/\r|\r\n|\n/), '\\end{cases}');
            var solution = formatInput('\\begin{pmatrix}', getCoefficients(), '\\end{pmatrix}');
            MathJax.Hub.Queue(["Text", vm.display, input]);
            MathJax.Hub.Queue(["Text", vm.solution, solution]);
        };

        vm.solve = function () {
            vm.isProcessing = true;
            $http.post('/Linear/Solve', { equations: vm.linearSystem.split(/\r|\r\n|\n/) })
                 .success(function (data) {
                    if (data.IsError) {
                        alert(data.Comment);
                    } else {
                        var solution = formatSolution(data.Data);
                        var result = formatInput('\\begin{pmatrix}', solution, '\\end{pmatrix}');
                        MathJax.Hub.Queue(["Text", vm.solution, result]);
                    }
                    vm.isProcessing = false;
                })
                 .error(function (data) {
                     alert(data);
                     vm.isProcessing = false;
                  });
        }
    }
    angular.module('mathMate-app')
        .controller("LinearController", ['$scope', '$http', linearController]);
})();