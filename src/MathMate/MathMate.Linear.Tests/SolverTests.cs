using Xunit;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear.Tests
{
    public class SolverTests
    {
        [Fact]
        public void SolveWithFreeTermsReturnsCorrectResult()
        {
            var matrix = DenseMatrix.OfArray(new double[,] {
        	    {3,2,-1},
        	    {2,-1,5},
                {1,7,-1}
		    });
            var freeTerms = Vector.Build.Dense(new double[] { 4, 23, 5 });
            var solver = new Solver();

            var actual = solver.Solve(matrix, freeTerms);
            var expected = Vector.Build.Dense(new double[] { 2, 1, 4 });

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void SolveWithoutFreeTermsReturnsCorrectResult()
        {
            var matrix = DenseMatrix.OfArray(new double[,] {
        	    {3,2,-1,4},
        	    {2,-1,5,23},
                {1,7,-1,5}
		    });
            var solver = new Solver();

            var actual = solver.Solve(matrix);
            var expected = Vector.Build.Dense(new double[] { 2, 1, 4 });

            Assert.Equal(expected, actual);
        }
    }
}