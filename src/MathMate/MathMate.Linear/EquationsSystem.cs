using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class EquationsSystem
    {
        public IEnumerable<Equation> Equations { get; private set; }

        public EquationsSystem(IEnumerable<Equation> equations)
        {
            Equations = equations;
        }

        public DenseMatrix GetMatrix()
        {
            var rows = new List<double[]>();
            foreach (var equation in Equations)
            {
                rows.Add(equation.EquationPairs.Select(x => x.Constant).ToArray());
            }

            var matrix = DenseMatrix.OfRowArrays(rows);

            return matrix;
        }

        public Vector<double> GetFreeTermsVector()
        {
            var constants = Equations.Select(x => x.Result.Constant).ToArray();
            var freeTerms = Vector.Build.Dense(constants);
            return freeTerms;
        }
    }
}