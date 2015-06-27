using System.Web.Mvc;
using MathMate.Linear;

namespace MathMate.Web.Controllers
{
    public class LinearController : Controller
    {
        private readonly ISolver solver;

        public LinearController(ISolver solver)
        {
            this.solver = solver;
        }

        public ActionResult Solve(string[] equations)
        {
            //var result = solver.Solve(null);

            return Json(equations);
        }
    }
}