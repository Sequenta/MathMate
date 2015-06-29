using MathNet.Numerics.LinearAlgebra;

namespace MathMate.Linear
{
    public interface ILinearEquationSystemSolver
    {
        Vector<double> Solve(EquationsSystem system);
    }
}