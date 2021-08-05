using Business;
using System.Web.Mvc;

namespace ASP_NET__Web_Application_NET_framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // ViewBag.Paginas = new PaginaSignin().Lista();

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

          /* ViewBag.Message = "Your application description page."; */

            return View();
        }

        public ActionResult Contact()
        {

            /* ViewBag.Message = "Your contact page.";*/

            ViewBag.Message = "Enjoy Is Fun.";

            return View();
        }
    }
}