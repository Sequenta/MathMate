using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MathMate.Linear.Exceptions;

namespace MathMate.Linear
{
    public class Equation
    {
        public IEnumerable<EquationPair> Result { get; private set; }
        public IEnumerable<EquationPair> EquationPairs { get; private set; }

        public Equation(IEnumerable<EquationPair> equationPairs, IEnumerable<EquationPair> result)
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
            if (match.Groups.Count != 3)
            {
                throw new ParsingException("One of equations has invalid format!");
            }
            var equationPairs = match.Groups[1].Value;
            var result = match.Groups[2].Value;
            var pairs = Regex.Matches(equationPairs, @"-?\d+[a-zA-Z]|-?[a-zA-Z]|-?\d+").Cast<Match>().Select(x => EquationPair.Parse(x.Value));
            var results = Regex.Matches(result, @"-?\d+[a-zA-Z]|-?[a-zA-Z]|-?\d+").Cast<Match>().Select(x => EquationPair.Parse(x.Value));
            return new Equation(pairs, results);
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
            var result = string.Join("",Result.Select(x => x.ToString()));
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
            equationPairs.AddRange(Result.Select(x => x.Inverse()));

            var resultConstant = equationPairs.Where(x => string.IsNullOrEmpty(x.Coefficient)).Sum(x => x.Constant);
            var result = new List<EquationPair>
            {
                new EquationPair(-resultConstant, string.Empty)
            }; 
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
            return (Result.Count() == 1 && string.IsNullOrEmpty(Result.First().Coefficient)) &&
                   (EquationPairs.GroupBy(x => x.Coefficient).All(x => x.Count() == 1));
        }
    }
}