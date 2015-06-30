using System.Collections.Generic;
using System.Linq;
using MathMate.Linear.Extensions;
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
            var coefficients = Equations.SelectMany(x => x.EquationPairs)
                                        .Where(x => !string.IsNullOrEmpty(x.Coefficient))
                                        .DistinctBy(x => x.Coefficient)
                                        .Select(x => x.Coefficient).ToList();
            foreach (var equation in Equations)
            {
                var constants = new double[coefficients.Count];
                for (var i = 0; i < coefficients.Count; i++)
                {
                    var equationPair = equation.EquationPairs.FirstOrDefault(x => x.Coefficient == coefficients[i]);
                    constants[i] = equationPair == null ? 0 : equationPair.Constant;
                }
                rows.Add(constants);
            }

            var matrix = DenseMatrix.OfRowArrays(rows);

            return matrix;
        }

        public Vector<double> GetFreeTermsVector()
        {
            var constants = Equations.Select(x => x.Result.First().Constant).ToArray();
            var freeTerms = Vector.Build.Dense(constants);
            return freeTerms;
        }
    }
}