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

        // Variables that will contain the chosen type and gender
        private static string queryGender;
        private static string queryType;

        public static List<NameModel> GetNameList(int limit)
        {
            // Sets the query string
            string query = "limit=" + limit;

            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList(query);
            
            return nameList;
        }

        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            // Sets the type variable
            SetQueryType(type);
            // Sets the query string
            string query = "limit=" + limit + "&type=" + GetQueryType();

            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList(query);

            return nameList;
        }

        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            // Sets the query gender
            SetQueryGender(gender);
            // Sets the query string
            string query = "limit=" + limit + "&gender=" + GetQueryGender();

            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList(query);

            return nameList;
        }

        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {
            // Sets the query type and gender
            SetQueryType(type);
            SetQueryGender(gender);
            // Sets the query string
            string query = "limit=" + limit + "&type=" + GetQueryType() + "&gender=" + queryGender;

            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList(query);

            return nameList;
        }

        private static void SetQueryType(NameType type)
        {
            // Sets queryType to the chosen type, defaults to Both
            switch (type)
            {
                case NameType.FirstName:
                    queryType = "firstname";
                    break;
                case NameType.SurName:
                    queryType = "surname";
                    break;
                case NameType.Both:
                    queryType = "both";
                    break;
                default:
                    queryType = "both";
                    break;
            }
        }

        public static string GetQueryType()
        {
            // returns the previous set queryType
            return queryType;
        }

        private static void SetQueryGender(NameGender gender)
        {
            // Sets queryGender to the chosen gender, defaults to Both
            switch (gender)
            {
                case NameGender.Male:
                    queryGender = "male";
                    break;
                case NameGender.Female:
                    queryGender = "female";
                    break;
                case NameGender.Both:
                    queryGender = "both";
                    break;
                default:
                    queryGender = "both";
                    break;
            }
        }

        private static string GetQueryGender()
        {
            // returns the previous set queryGender
            return queryGender;
        }

        private static List<NameModel> PrepareNameList(string query)
        {
            // Retreives JsonModel from api url with query-string
            JsonModel apiResponse = GetApiResponse(query);

            // Go through all name-objects and populate the list
            List<NameModel> nameList = PopulateNameModelList(apiResponse);
            return nameList;
        }

        private static JsonModel GetApiResponse(string query)
        {
            // Retreives json-string from api url with query
            var apiStringResponse = new WebClient().DownloadString(apiUrl + query);

            // Used to convert the json string into model JsonModel
            JsonModel apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonModel>(apiStringResponse);

            return apiResponse;
        }

        private static List<NameModel> PopulateNameModelList(JsonModel apiResponse)
        {
            // creates list to be returned
            List<NameModel> nameModelList = new List<NameModel>();

            // Goes through alla names from the api response
            for (int i = 0; i < apiResponse.names.Count; i++)
            {
                // Create NameModel object
                NameModel item = new NameModel();

                // Populate the item object with data from the current name iterated
                item.FirstName = apiResponse.names[i].firstname;
                item.LastName = apiResponse.names[i].surname;

                // Checks gender type
                switch (apiResponse.names[i].gender)
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
    }
}
