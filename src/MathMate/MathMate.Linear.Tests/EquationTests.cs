using System.Linq;
using Xunit;

namespace MathMate.Linear.Tests
{
    public class EquationTests
    {
        [Theory]
        [InlineData("3x+y-2z-1x+2y=1")]
        [InlineData("3x+y-2-1x+2y-2z=1")]
        public void ToStringTest(string equation)
        {
            var parsedEquation = Equation.Parse(equation);

            Assert.Equal(equation, parsedEquation.ToString());
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

            Assert.Equal("1", parsedEquation.Result.First().ToString());
        }

        [Theory]
        [InlineData("3x+y-2z-1x+2y=1", "2x+3y-2z=1")]
        [InlineData("3x+y=2z", "3x+y-2z=0")]
        [InlineData("3x+y-2-1x+2y-2z=1", "2x+3y-2z=3")]
        [InlineData("3x+y-1x+1x+2y-2z=3", "3x+3y-2z=3")]
        [InlineData("2x=3-y", "2x+y=3")]
        [InlineData("y=4", "y=4")]
        public void SimplifyReturnsEquationWithFeverEquationPairs(string equation, string result)
        {
            var parsedEquation = Equation.Parse(equation);

            var simplifiedEquation = parsedEquation.Simplify();

            Assert.Equal(result, simplifiedEquation.ToString());
        }
    }
}