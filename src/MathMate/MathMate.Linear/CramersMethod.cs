using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class CramersMethod : ISolutionMethod
    {
        public Vector<double> Solve(DenseMatrix systemMatrix, Vector<double> freeTerms)
        {
            var determinant = systemMatrix.Determinant();
            var determinants = new double[systemMatrix.ColumnCount];
            var results = new double[systemMatrix.ColumnCount];
            for (var i = 0; i < systemMatrix.ColumnCount; i++)
            {
                var matrix = systemMatrix.RemoveColumn(i).InsertColumn(i, freeTerms);
                determinants[i] = matrix.Determinant();
            }
            for (var i = 0; i < determinants.Length; i++)
            {
                results[i] = determinants[i]/determinant;
            }
            return Vector.Build.Dense(results);
        }
    }
}