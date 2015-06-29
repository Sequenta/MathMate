using Xunit;

namespace MathMate.Linear.Tests
{
    public class EquationPairTests
    {
        [Fact]
        public void ParseTest()
        {
            var equationPair = EquationPair.Parse("-3x");

            Assert.Equal("x",equationPair.Coefficient);
            Assert.Equal(-3, equationPair.Constant);
        }

        [Fact]
        public void ToStringTest()
        {
            var equationPair = EquationPair.Parse("x3");

            Assert.Equal("3x",equationPair.ToString());
        }
    }
}