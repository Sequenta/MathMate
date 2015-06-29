using System;
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
            var match = Regex.Match(equationString, @"([^=]*)=([^=]*)");
            var equationPairs = match.Groups[1].Value;
            var result = match.Groups[2].Value;
            var pairs = Regex.Matches(equationPairs, @"-?\d+[a-zA-Z]|-?[a-zA-Z]|-?\d+").Cast<Match>().Select(x => EquationPair.Parse(x.Value));
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

        public Equation Simplify()
        {
            if (IsSimplified())
            {
                return this;
            }
            var equationPairs = new List<EquationPair>();
            equationPairs.AddRange(EquationPairs);
            equationPairs.Add(new EquationPair(-Result.Constant,Result.Coefficient));

            var resultConstant = equationPairs.Where(x => string.IsNullOrEmpty(x.Coefficient)).Sum(x => x.Constant);
            var result = new EquationPair(-resultConstant, string.Empty);
            var simplifiedEquationPairs = new List<EquationPair>();
            foreach (var equationPair in equationPairs.Where(x => !string.IsNullOrEmpty(x.Coefficient)))
            {
                var coefficient = equationPair.Coefficient;
                if (simplifiedEquationPairs.Any(x => x.Coefficient == coefficient)) 
                    continue;
                var constant = equationPairs.Where(x => x.Coefficient == coefficient).Sum(x => x.Constant);
                simplifiedEquationPairs.Add(new EquationPair(constant, coefficient));
            }
            return new Equation(simplifiedEquationPairs, result);
        }

        public bool IsSimplified()
        {
            var equationPairs = new List<EquationPair>
            {
                Result
            };
            equationPairs.AddRange(EquationPairs);

            return equationPairs.GroupBy(x => x.Coefficient).All(x => x.Count() == 1) &&
                   string.IsNullOrEmpty(Result.Coefficient);
        }
    }
}