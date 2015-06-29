using System.Linq;
using Xunit;

namespace MathMate.Linear.Tests
{
    public class EquationTests
    {
        [Fact]
        public void ToStringTest()
        {
            var equationString = "3x+4y-2z=1";
            var parsedEquation = Equation.Parse(equationString);

            Assert.Equal(equationString, parsedEquation.ToString());
        }

        [Fact]
        public void IsSimplifiedReturnsTrueForSimpleEquation()
        {
            var equationString = "3x+4y-2z=1";
            var parsedEquation = Equation.Parse(equationString);

            Assert.True(parsedEquation.IsSimplified());
        }

        [Fact]
        public void EquationPairsAndResultParsedCorrectly()
        {
            var equationString = "3x+y-2z=1";
            var parsedEquation = Equation.Parse(equationString);
            var pairs = parsedEquation.EquationPairs.ToList();

            Assert.Equal(3, pairs.Count);
            Assert.Equal("3x", pairs[0].ToString());
            Assert.Equal("y", pairs[1].ToString());
            Assert.Equal("-2z", pairs[2].ToString());

            Assert.Equal("1", parsedEquation.Result.ToString());
        }

        [Fact]
        public void SimplifyReturnsEquationWithFeverEquationPairs()
        {
            var equationString = "3x+y-2z-1x+2y=1";
            var parsedEquation = Equation.Parse(equationString);

            var simplifiedEquation = parsedEquation.Simplify();

            Assert.Equal("2x+3y-2z=1", simplifiedEquation.ToString());
        }
    }
}