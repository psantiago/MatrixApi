using System.Web.Mvc;
using StackExchange.Profiling;

namespace MatrixApi.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var profiler = MiniProfiler.Current;
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// The login page
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
