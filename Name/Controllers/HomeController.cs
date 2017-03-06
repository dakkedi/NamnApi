using System.Web.Mvc;
using Name.Models;
using NameAPI.Models;
using System.Collections.Specialized;
using System;
using System.Diagnostics;

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
                NameType nameTypeValue = (NameType)Enum.Parse(typeof(NameType) , FormData.Get("nameTypeData"));
                NameGender nameGenderValue = (NameGender)Enum.Parse(typeof(NameGender), FormData.Get("nameTypeData"));
                int nameAmountValue = int.Parse( FormData.Get("nameAmountData") );
                ViewBag.Names = NameController.GetNames(nameTypeValue, nameGenderValue, nameAmountValue);
            }
            else
            {
                ViewBag.Names = NameController.GetNames();
            }
            return View();
        }
    }
}