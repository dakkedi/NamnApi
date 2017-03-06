using System.Collections.Generic;
using System.Web.Mvc;
using NameAPI.Models;
using System;
using Name.Models;
using System.Collections.Specialized;

namespace Name.Controllers
{
    public class NameController : Controller
    {
        /// <summary>
        /// Gets list of names from NameAPi.NameService
        /// </summary>
        /// <param name="nameType"></param>
        /// <param name="nameGender"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<NameModel> GetNames()
        {
            int defaultLimit = 10;
            List<NameModel> nameModelList = NameAPI.NameService.GetNameList(defaultLimit);
            
            return nameModelList;
        }

        public static List<NameModel> GetNames(NameValueCollection FormData)
        {
            NameType nameTypeValue = (NameType)Enum.Parse(typeof(NameType), FormData.Get("nameTypeData"));
            NameGender nameGenderValue = (NameGender)Enum.Parse(typeof(NameGender), FormData.Get("nameTypeData"));
            int nameLimitValue = int.Parse(FormData.Get("nameLimitData"));

            List<NameModel> nameModelList = NameAPI.NameService.GetNameList(nameTypeValue, nameGenderValue, nameLimitValue);

            return nameModelList;
        }

        /// <summary>
        /// Prepares and returns html select-list for gender options
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGenderDropdown()
        {
            var dropdownModel = GetGenderDropdownModel(new NameDropdownModel());

            return PartialView(Url.Content("~/Views/FormDropdowns/GenderDropdown.cshtml"), dropdownModel);
        }

        /// <summary>
        /// Prepares data for gender dropdown list
        /// </summary>
        /// <param name="dropdownModel"></param>
        /// <returns></returns>
        private static NameDropdownModel GetGenderDropdownModel(NameDropdownModel dropdownModel)
        {
            dropdownModel.GenderItems = new List<NameGenderModel>();
            foreach ( var genderItem in Enum.GetValues( typeof( NameGender ) ) )
            {
                dropdownModel.GenderItems.Add(new NameGenderModel() { Value = (int)genderItem, Text = genderItem.ToString() });
            }
            return dropdownModel;
        }

        /// <summary>
        /// Prepares and returns html select-list for type options
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTypeDropdown()
        {
            var dropdownModel = GetTypeDropdownModel(new NameDropdownModel());

            return PartialView(Url.Content("~/Views/FormDropdowns/TypeDropdown.cshtml"), dropdownModel);
        }

        /// <summary>
        /// Prepares data for type dropdown list
        /// </summary>
        /// <param name="dropdownModel"></param>
        /// <returns></returns>
        private static NameDropdownModel GetTypeDropdownModel(NameDropdownModel dropdownModel)
        {
            dropdownModel.TypeItems = new List<NameTypeModel>();
            foreach (var typeItem in Enum.GetValues(typeof(NameType)))
            {
                dropdownModel.TypeItems.Add(new NameTypeModel() { Value = (int)typeItem, Text = typeItem.ToString() });
            }
            return dropdownModel;
        }

        /// <summary>
        /// Form action, redirects to Index view in Home controller
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostGetNames()
        {
            TempData["form"] = Request.Form;
            return RedirectToAction("Index", "Home", Request.Form);
        }
    }
}