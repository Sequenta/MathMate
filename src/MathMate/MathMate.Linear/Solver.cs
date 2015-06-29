using MathMate.Linear.Extensions;
using MathNet.Numerics.LinearAlgebra;

namespace MathMate.Linear
{
    public class Solver : ILinearEquationSystemSolver
    {
        private ISolutionMethod strategy;

        public Vector<double> Solve(EquationsSystem system)
        {
            var systemMatrix = system.GetMatrix();
            var freeTerms = system.GetFreeTermsVector();
            if (systemMatrix.IsSquare())
            {
                strategy = new MatrixMethod();
            }
            return strategy.Solve(systemMatrix,freeTerms);
        }
    }
}