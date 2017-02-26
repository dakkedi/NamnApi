using System.Collections.Generic;
using System.Web.Mvc;
using NameAPI.Models;
using Name.Models;
using System.Diagnostics;

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

        [HttpPost]
        public ActionResult ShowNames(NameFormModel formData)
        {
            Debug.WriteLine("formData");
            Debug.WriteLine(formData);
            return RedirectToAction("Index");
        }
    }
}