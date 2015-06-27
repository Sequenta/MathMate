using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MathMate.Linear
{
    public class Equation
    {
        public EquationPair Result { get; private set; }
        public IEnumerable<EquationPair> EquationPairs { get; private set; }

        public Equation(IEnumerable<EquationPair> equationPairs, EquationPair result)
        {
            EquationPairs = equationPairs;
            Result = result;
        }

        public Equation(string equationString)
        {
            var equation = Parse(equationString);
            Result = equation.Result;
            EquationPairs = equation.EquationPairs;
        }


        public static Equation Parse(string equationString)
        {
            equationString = equationString.Replace(" ", "");
            var result = Regex.Match(equationString, @"(?<==)-?\d+").Value;
            var pairs = Regex.Matches(equationString, @"-?\d+[a-zA-Z]|-?[a-zA-Z]").Cast<Match>().Select(x => EquationPair.Parse(x.Value));
            return new Equation(pairs, EquationPair.Parse(result));
        }

        public override string ToString()
        {
            var pairs = string.Join("",EquationPairs.Select(x =>
            {
                if (x.Constant>=0)
                {
                    return "+" + x.ToString();
                }
                return x.ToString();
            })).Trim('+');
            var result = Result.ToString();
            return string.Format("{0}={1}", pairs, result);
        }
    }
}