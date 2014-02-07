using System.Web.Mvc;

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
