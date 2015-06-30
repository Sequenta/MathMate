using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;
using Xunit;

namespace MathMate.Linear.Tests
{
    public class EquationsSystemTests
    {
        [Fact]
        public void GetMatrixReturnsDenseMatrixOfExpectedSize()
        {
            var equations = new List<Equation>
            {
                new Equation("3x+2y-5z=2"),
                new Equation("5x+3y-8z=7"),
                new Equation("6x+8y-3z=1")
            };
            var equationsSystem = new EquationsSystem(equations);
            var expectedMatrix = DenseMatrix.OfArray(new double[,]
            {
                {3,2,-5},
                {5,3,-8},
                {6,8,-3}
            });

            var equationMatrix = equationsSystem.GetMatrix();

            Assert.Equal(expectedMatrix, equationMatrix);
        }

        [Fact]
        public void GetMatrixReturnsDenseMatrixOfExpectedSizeIfCoefficientsMissing()
        {
            var equations = new List<Equation>
            {
                new Equation("2x+y=3"),
                new Equation("y=4")
            };
            var equationsSystem = new EquationsSystem(equations);
            var expectedMatrix = DenseMatrix.OfArray(new double[,]
            {
                {2,1},
                {0,1}
            });

            var equationMatrix = equationsSystem.GetMatrix();

            Assert.Equal(expectedMatrix, equationMatrix);
        }

        [Fact]
        public void GetResultsVectorReturnsFreeTermsVectorForSystem()
        {
            var equations = new List<Equation>
            {
                new Equation("3x+2y-5z=2"),
                new Equation("5x+3y-8z=7"),
                new Equation("6x+8y-3z=1")
            };
            var equationsSystem = new EquationsSystem(equations);
            var expectedVector = Vector.Build.Dense(new double[] {2, 7, 1});

            var resultsVector = equationsSystem.GetFreeTermsVector();

            Assert.Equal(expectedVector,resultsVector);
        }
    }
}