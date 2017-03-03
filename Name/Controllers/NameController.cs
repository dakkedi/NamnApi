using System.Collections.Generic;
using System.Web.Mvc;
using NameAPI.Models;
using System;
using Name.Models;

namespace Name.Controllers
{
    public class NameController : Controller
    {


        // GET: Name
        public static List<NameModel> GetNames(NameType nameType = NameType.Both, NameGender namegender = NameGender.Both, int amount = 10)
        {
            List<NameModel> nameModelList = NameAPI.NameService.GetNameList(nameType, namegender, amount);
            
            return nameModelList;
        }

        public ActionResult GetGenderDropdown()
        {
            var dropdownModel = GetGenderDropdownModel(new NameDropdownModel());

            return PartialView(Url.Content("~/Views/FormDropdowns/GenderDropdown.cshtml"), dropdownModel);
        }

        private static NameDropdownModel GetGenderDropdownModel(NameDropdownModel dropdownModel)
        {
            dropdownModel.GenderItems = new List<NameGenderModel>();
            foreach ( var genderItem in Enum.GetValues( typeof( NameGender ) ) )
            {
                dropdownModel.GenderItems.Add(new NameGenderModel() { Value = (int)genderItem, Text = genderItem.ToString() });
            }
            return dropdownModel;
        }

        [HttpPost]
        public ActionResult GetNames(FormPostModel post)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}