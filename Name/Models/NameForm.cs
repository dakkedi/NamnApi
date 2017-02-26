using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameAPI.Models;

namespace Name.Models
{
    public class NameForm
    {
        public NameForm()
        {
            TypeItems = new SelectList(new[] { NameType.Both, NameType.FirstName, NameType.SurName });
            GenderItems = new SelectList(new[] { NameGender.Both, NameGender.Male, NameGender.Female });
            CurrentTypeId = NameType.Both;
            CurrentGenderItem = NameGender.Both;
        }

        public NameType CurrentTypeId { get; set; }
        public IEnumerable<SelectListItem> TypeItems;
        //public SelectList TypeItems { get; set; }

        public NameGender CurrentGenderItem { get; set; }
        public IEnumerable<SelectListItem> GenderItems;
        //public SelectList GenderItems { get; set; }
    }
}