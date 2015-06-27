using System.Web.Mvc;

namespace MathMate.Web.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}