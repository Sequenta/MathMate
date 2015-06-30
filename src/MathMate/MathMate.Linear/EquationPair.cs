using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace MathMate.Linear
{
    public class EquationPair
    {
        public double Constant { get; set; }
        public string Coefficient{ get; set; }

        public EquationPair(double constant, string coefficient)
        {
            Constant = constant;
            Coefficient = coefficient;
        }

        public EquationPair(string equationPair)
        {
            var result= Parse(equationPair);
            Constant = result.Constant;
            Coefficient = result.Coefficient;
        }

        public static EquationPair Parse(string equationPair)
        {
            var coefficientString = Regex.Match(equationPair, @"-?[a-zA-Z]").Value;
            var constantString = Regex.Match(equationPair, @"-?\d+").Value;
            double constant;
            if (string.IsNullOrEmpty(constantString))
            {
                constant = coefficientString.Contains("-") ? -1 : 1;
            }
            else
            {
                constant = double.Parse(constantString);
            }
            return new EquationPair(constant,coefficientString.Replace("-",""));
        }

        public EquationPair Inverse()
        {
            return new EquationPair(-Constant,Coefficient);
        }

        public override string ToString()
        {
            var constant = Constant.ToString();
            if (!string.IsNullOrEmpty(Coefficient))
            {
                if (Constant == 1)
                {
                    constant = string.Empty;
                }
            }
            return string.Format("{0}{1}", constant, Coefficient);
        }
    }
}