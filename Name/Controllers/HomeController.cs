using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameAPI.Models;

namespace Name.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<NameModel> nameModelList = NameAPI.NameService.GetNameList(10);
            ViewBag.Names = nameModelList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}