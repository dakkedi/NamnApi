using System.Web.Mvc;
using NameAPI.Models;
using System.Collections.Specialized;
using System;

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
            if (TempData["form"] != null)
            {
                NameValueCollection FormData = (NameValueCollection)TempData["form"];
                
                ViewBag.Names = NameController.GetNames(FormData);
            }
            else
            {
                ViewBag.Names = NameController.GetNames();
            }
            return View();
        }
    }
}