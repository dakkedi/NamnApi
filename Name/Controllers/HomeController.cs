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
            NameValueCollection FormData = null;
            if (TempData["form"] != null)
            {
                FormData = (NameValueCollection)TempData["form"];

                ViewBag.Names = NameController.GetNames(FormData);
            }
            else
            {
                ViewBag.Names = NameController.GetNames();
            }

            TempData["limit"] = FormData != null ? FormData.Get("nameLimitData") : "10";
            TempData["type"] = FormData != null ? FormData.Get("nameTypeData") : "0";
            TempData["gender"] = FormData != null ? FormData.Get("nameGenderData") : "0";
            return View();
        }
    }
}