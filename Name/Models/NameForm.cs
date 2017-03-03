using System.Collections.Generic;
using System.Web.Mvc;
using NameAPI.Models;

namespace Name.Models
{
    //public class NameForm
    //{
    //    public NameForm()
    //    {
    //        TypeItems = new SelectList(new[] { NameType.Both, NameType.FirstName, NameType.SurName });
    //        GenderItems = new SelectList(new[] { NameGender.Both, NameGender.Male, NameGender.Female });
    //        CurrentTypeId = NameType.Both;
    //        CurrentGenderItem = NameGender.Both;
    //    }

    //    public NameType CurrentTypeId { get; set; }
    //    public IEnumerable<SelectListItem> TypeItems { get; set; }

    //    public NameGender CurrentGenderItem { get; set; }
    //    public IEnumerable<SelectListItem> GenderItems { get; set; }
    //}

    public class NameDropdownModel
    {
        public List<NameTypeModel> TypeItems { get; set; }
        public List<NameGenderModel> GenderItems { get; set; }
    }

    public class NameTypeModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class NameGenderModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class FormPostModel
    {
        public int nameGenderData;
        public int nameTypeData;
        public int nameAmountData;
    }
}