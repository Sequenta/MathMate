using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathMate.Linear
{
    public class EquationsSystem
    {
        private readonly IEnumerable<Equation> equations;

        public EquationsSystem(IEnumerable<Equation> equations)
        {
            this.equations = equations;
        }

        public DenseMatrix GetMatrix()
        {
            foreach (var equation in equations)
            {
                
            }
            return null;
        }
    }
}