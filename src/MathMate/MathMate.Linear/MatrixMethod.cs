using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class MatrixMethod : ISolutionMethod
    {
        public Vector<double> Solve(DenseMatrix systemMatrix, Vector<double> freeTerms)
        {
            return systemMatrix.Inverse().Multiply(freeTerms);
        }     
    }
}