using System;
using System.Collections.Generic;

namespace NameAPI.Models
{
    public class JsonModel
    {
        public List<JsonModelInner> names; 
    }
    public class JsonModelInner
    {
        public string firstname;
        public string surname;
        public string gender;
    }
}
