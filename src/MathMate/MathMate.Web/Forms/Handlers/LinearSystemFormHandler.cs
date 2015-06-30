﻿using System;
using System.Linq;
using MathMate.Linear;
using MathNet.Numerics.LinearAlgebra;

namespace MathMate.Web.Forms.Handlers
{
    public class LinearSystemFormHandler : FormHandler<string[],Vector<double>>
    {
        private readonly ILinearEquationSystemSolver solver;

        public LinearSystemFormHandler(ILinearEquationSystemSolver solver)
        {
            this.solver = solver;
        }

        protected override IFormResult<Vector<double>> InnerValidate(string[] form)
        {
            if (form == null)
            {
                return FormResult<Vector<double>>.ErrorResult("System can not be empty!");
            }
            return FormResult<Vector<double>>.SuccessResult(null);
        }

        protected override IFormResult<Vector<double>> InnerHandle(string[] form)
        {
            Vector<double> result;
            try
            {
                var equations = form.Select(Equation.Parse);
                var equationSystem = new EquationsSystem(equations);
                result = solver.Solve(equationSystem);
            }
            catch (Exception e)
            {
                return FormResult<Vector<double>>.ErrorResult(e.Message);
            }

            return FormResult<Vector<double>>.SuccessResult(result);
        }
    }
}