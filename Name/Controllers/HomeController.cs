using System.Web.Mvc;

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