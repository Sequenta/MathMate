using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public interface ISolutionMethod
    {
        Vector<double> Solve(DenseMatrix systemMatrix, Vector<double> freeTerms);
    }
}