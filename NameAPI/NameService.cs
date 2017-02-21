using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;
using NameAPI.Models;


namespace NameAPI
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
    public class NameService
    {
        // Variable that contains the api url.
        private static string apiUrl = "http://api.namnapi.se/v2/names.json?";

        public static List<NameModel> GetNameList(int limit)
        {
            // Sets the query string
            string query = "limit=" + limit;
            // Retreives json-string from api url with query
            var apiResponse = new WebClient().DownloadString(apiUrl+query);
            // Used to convert the json string into the models predefined
            JsonModel jsonModel = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonModel>(apiResponse);

            // Create the list that should be returned
            List<NameModel> nameModelList = new List<NameModel>();

            // Go through all name-objects 
            /* 
                Chris: foreach(var whateverTheFuckEver in myList){
                           whateverTheFuckEver.property = 0;
                        }
                        myList måste då vara en List<>
                        och sedan om du vill ha myList till en array
                        var myArray = myList.ToArray()
            */
            for (int i = 0; i < jsonModel.names.Count; i++)
            {
                // Create NameModel object
                NameModel item = new NameModel();

                // Populate the item object with data from the retrieved list
                item.FirstName = jsonModel.names[i].firstname;
                item.LastName = jsonModel.names[i].surname;

                // Checks gender type
                switch (jsonModel.names[i].gender)
                {
                    case "both":
                        item.Gender = NameGender.Both;
                        break;
                    case "male":
                        item.Gender = NameGender.Male;
                        break;
                    case "female":
                        item.Gender = NameGender.Female;
                        break;
                }
                // Lastly adds the NameModel object into the NameModel List
                nameModelList.Add(item);
            }

            return nameModelList;
        }

        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            // todo: your code here

            return new List<NameModel>();
        }

        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            // todo: your code here

            return new List<NameModel>();
        }

        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {
            // todo: your code here

            return new List<NameModel>();
        }


    }
}
