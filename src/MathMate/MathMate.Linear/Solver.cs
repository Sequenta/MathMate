using MathMate.Linear.Extensions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class Solver : ISolver
    {
        private ISolutionMethod strategy;

        public Vector<double> Solve(DenseMatrix systemMatrix, Vector<double> freeTerms)
        {
            if (systemMatrix.IsSquare())
            {
                strategy = new MatrixMethod();
            }
            return strategy.Solve(systemMatrix,freeTerms);
        }
        public Vector<double> Solve(DenseMatrix systemMatrix)
        {
            var freeTerms = systemMatrix.ExtractFreeTerms();
            systemMatrix = DenseMatrix.OfMatrix(systemMatrix.RemoveColumn(systemMatrix.ColumnCount-1));
            return Solve(systemMatrix, freeTerms);
        }
    }
}