using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public interface ISolver
    {
        Vector<double> Solve(DenseMatrix systemMatrix, Vector<double> freeTerms);
        Vector<double> Solve(DenseMatrix systemMatrix);
    }
}