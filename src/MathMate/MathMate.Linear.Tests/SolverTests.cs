﻿using System.Collections.Generic;
using Xunit;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear.Tests
{
    public class SolverTests
    {
        [Fact]
        public void SolveReturnsCorrectResult()
        {
            var equations = new List<Equation>
            {
                new Equation("x+3y-2z=5"),
                new Equation("3x+5y+6z=7"),
                new Equation("2x+4y+3z=8")
            };
            var equationsSystem = new EquationsSystem(equations);
            var solver = new Solver();
            var expectedResult = Vector.Build.Dense(new double[] {-15, 8, 2});

            var result = solver.Solve(equationsSystem);

            Assert.Equal(expectedResult.ToString(), result.ToString());
        }

        [Fact]
        public void SolveSimplifiesSystemAndReturnsCorrectResult()
        {
            var equations = new List<Equation>
            {
                new Equation("x+2y+1y-2z-1=4"),
                new Equation("x+2x+5y+6z+2=9"),
                new Equation("2x+4y+3z=8")
            };
            var equationsSystem = new EquationsSystem(equations);
            var solver = new Solver();
            var expectedResult = Vector.Build.Dense(new double[] { -15, 8, 2 });

            var result = solver.Solve(equationsSystem);

            Assert.Equal(expectedResult.ToString(), result.ToString());
        }

        [Fact]
        public void SolveByCramersMethodReturnsCorrectResult()
        {
            var equations = new List<Equation>
            {
                new Equation("2x+y=3"),
                new Equation("y=4")
            };
            var equationsSystem = new EquationsSystem(equations);
            var solver = new Solver();
            var expectedResult = Vector.Build.Dense(new[] { -0.5, 4 });

            var result = solver.Solve(equationsSystem);

            Assert.Equal(expectedResult.ToString(), result.ToString());
        }
    }
}