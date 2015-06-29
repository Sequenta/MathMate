using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class EquationsSystem
    {
        private readonly IEnumerable<Equation> equations;

        public EquationsSystem(IEnumerable<Equation> equations)
        {
            this.equations = equations;
        }

        public DenseMatrix GetMatrix()
        {
            var rows = new List<double[]>();
            foreach (var equation in equations)
            {
                rows.Add(equation.EquationPairs.Select(x => x.Constant).ToArray());
            }

            var matrix = DenseMatrix.OfRowArrays(rows);

            return matrix;
        }

        public Vector<double> GetResultsVector()
        {
            var constants = equations.Select(x => x.Result.Constant).ToArray();
            var resultsVector = Vector.Build.Dense(constants);
            return resultsVector;
        }
    }
}