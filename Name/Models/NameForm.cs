using System.Collections.Generic;
using System.Web.Mvc;
using NameAPI.Models;

namespace Name.Models
{
    /// <summary>
    /// Model for the type and gender lists
    /// </summary>
    public class NameDropdownModel
    {
        public List<NameTypeModel> TypeItems { get; set; }
        public List<NameGenderModel> GenderItems { get; set; }
    }

    /// <summary>
    /// Model for the values of NameType enum
    /// </summary>
    public class NameTypeModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    /// <summary>
    /// Model for the values of NameGender enum
    /// </summary>
    public class NameGenderModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    /// <summary>
    /// Model for the form post values
    /// </summary>
    public class FormPostModel
    {
        public int nameGenderData;
        public int nameTypeData;
        public int nameAmountData;
    }
}