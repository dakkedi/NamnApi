using System.Web.Mvc;
using Name.Models;
using NameAPI.Models;

namespace Name.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default view for Home controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Names = NameController.GetNames();

            return View();
        }
    }
}