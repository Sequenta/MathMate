using System;
using System.Linq;
using MathMate.Linear.Exceptions;
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
                if (systemMatrix.RowCount<3)
                {
                    strategy = new CramersMethod();
                }
                else
                {
                    strategy = new MatrixMethod();
                }
                
            }
            Vector<double> result;
            try
            {
                result = strategy.Solve(systemMatrix,freeTerms);
            }
            catch (Exception)
            {
                throw new SolverEsception("Unsupported type of equation system!");
            }
            return result;
        }

        private EquationsSystem Simplify(EquationsSystem system)
        {
            var simplifiedEquations = system.Equations.Select(x => x.Simplify());
            return new EquationsSystem(simplifiedEquations);
        }
    }
}