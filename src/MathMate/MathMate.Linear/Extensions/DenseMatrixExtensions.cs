using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear.Extensions
{
    public static class DenseMatrixExtensions
    {
        public static Vector<double> ExtractFreeTerms(this DenseMatrix denseMatrix)
        {
            var lastElementIndex = denseMatrix.ColumnCount -1;
            var freeTerms = new double[denseMatrix.RowCount];
            for (var i = 0; i < denseMatrix.RowCount; i++)
            {
                freeTerms[i] = denseMatrix[i, lastElementIndex];
            }
            
            return Vector.Build.Dense(freeTerms);
        }

        public static bool IsSquare(this DenseMatrix denseMatrix)
        {
            return denseMatrix.ColumnCount == denseMatrix.RowCount;
        }
    }
}