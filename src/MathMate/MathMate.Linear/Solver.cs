using System.Linq;
using MathMate.Linear.Extensions;
using MathNet.Numerics.LinearAlgebra;

namespace MathMate.Linear
{
    public class Solver : ILinearEquationSystemSolver
    {
        private ISolutionMethod strategy;

        public Vector<double> Solve(EquationsSystem system)
        {
            var simplifiedSystem = Simplify(system);
            var systemMatrix = simplifiedSystem.GetMatrix();
            var freeTerms = simplifiedSystem.GetFreeTermsVector();
            if (systemMatrix.IsSquare())
            {
                strategy = new MatrixMethod();
            }
            return strategy.Solve(systemMatrix,freeTerms);
        }

        private EquationsSystem Simplify(EquationsSystem system)
        {
            var simplifiedEquations = system.Equations.Select(x => x.Simplify());
            return new EquationsSystem(simplifiedEquations);
        }
    }
}