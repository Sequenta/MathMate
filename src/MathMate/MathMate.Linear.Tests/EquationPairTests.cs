using Xunit;

namespace MathMate.Linear.Tests
{
    public class EquationPairTests
    {
        [Theory]
        [InlineData("-3x","x",-3)]
        [InlineData("-x","x",-1)]
        [InlineData("3","",3)]
        public void ParseTest(string equationPair, string coefficient, double constant)
        {
            var result = EquationPair.Parse(equationPair);

            Assert.Equal(coefficient,result.Coefficient);
            Assert.Equal(constant, result.Constant);
        }

        [Fact]
        public void ToStringTest()
        {
            var equationPair = EquationPair.Parse("x3");

            Assert.Equal("3x",equationPair.ToString());
        }
    }
}