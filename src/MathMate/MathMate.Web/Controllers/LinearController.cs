using System.Web.Mvc;
using MathMate.Web.Forms.Handlers;

namespace MathMate.Web.Controllers
{
    public class LinearController : Controller
    {
        private readonly LinearSystemFormHandler formHandler;

        public LinearController(LinearSystemFormHandler formHandler)
        {
            this.formHandler = formHandler;
        }

        public ActionResult Solve(string[] equations)
        {
            var result = formHandler.Handle(equations);
            return Json(result);
        }
    }
}