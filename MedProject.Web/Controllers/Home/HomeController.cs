using System.Web.Mvc;

namespace MedProject.Web.Controllers.Home
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}