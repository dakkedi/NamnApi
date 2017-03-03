using System.Web.Mvc;
using Name.Models;
using NameAPI.Models;

namespace Name.Controllers
{
    public class HomeController : Controller
    {
        // creating a variable to the NameController
        //private NameController NameCont = new NameController();

        public ActionResult Index()
        {
            ViewBag.Names = NameController.GetNames();

            return View();
        }
    }
}