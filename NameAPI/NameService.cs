using System.Collections.Generic;
using System.Net;
using NameAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NameAPI
{
    /// <summary>
    /// Model for names
    /// </summary>
    public class JsonNamesModel
    {
        public string firstname;
        public string surname;
        public string gender;
    }

    /// <summary>
    /// Class that handles the query string
    /// </summary>
    public class QueryValues
    {
        public string limit = "10";
        public string type = "both";
        public string gender = "both";

        private string query;

        /// <summary>
        /// Constructor calls setQueryString()
        /// </summary>
        public QueryValues()
        {
            setQueryString(limit, type, gender);
        }

        /// <summary>
        /// Overrides current query string
        /// </summary>
        private void setQueryString(string plimit, string ptype, string pgender)
        {
            query = "?limit=" + limit + "&type=" + type + "&gender=" + gender;
        }

        /// <summary>
        /// Sets and returns the current query string
        /// </summary>
        /// <returns>string</returns>
        public string getQueryString()
        {
            setQueryString(limit, type, gender);
            return query;
        }

    }

    /// <summary>
    /// Class that handles the name api
    /// </summary>
    public class NameService
    {
        private static string apiUrl = "http://api.namnapi.se/v2/names.json";

        private static QueryValues queryValues = new QueryValues();

        /// <summary>
        /// Prepares list of names based on the limit input
        /// </summary>
        /// <param name="limit"></param>
        public static List<NameModel> GetNameList(int limit)
        {
            queryValues.limit = limit.ToString();
            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList();
            
            return nameList;
        }

        /// <summary>
        /// Prepares list of names based on the limit input and type of name
        /// </summary>
        /// <param name="type"></param>
        /// <param name="limit"></param>
        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            queryValues.type = type.ToString().ToLower();
            queryValues.limit = limit.ToString();
            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList();

            return nameList;
        }

        /// <summary>
        /// Prepares list of names based on the limit input and gender
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="limit"></param>
        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            queryValues.gender = gender.ToString().ToLower();
            queryValues.limit = limit.ToString();
            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList();

            return nameList;
        }

        /// <summary>
        /// Prepares list of names based on the limit input, tyoe of name and gender
        /// </summary>
        /// <param name="type"></param>
        /// <param name="gender"></param>
        /// <param name="limit"></param>
        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {

            queryValues.type = type.ToString().ToLower();
            queryValues.gender = gender.ToString().ToLower();
            queryValues.limit = limit.ToString();
            // Prepares a list of names from the response of the query
            List<NameModel> nameList = PrepareNameList();

            return nameList;
        }

        /// <summary>
        /// Gets the response from API call and prepares a list of names
        /// </summary>
        private static List<NameModel> PrepareNameList()
        {
            // Retreives JsonModel from api url with query-string
            Dictionary<string, List<JsonNamesModel>> apiResponse = GetApiResponse();

            // Go through all name-objects and populate the list
            List<NameModel> nameList = PopulateNameModelList(apiResponse);
            return nameList;
        }

        /// <summary>
        /// Gets query string and makes api call. Then converts the string from api call into a List object
        /// </summary>
        private static Dictionary<string, List<JsonNamesModel>> GetApiResponse()
        {
            string query = queryValues.getQueryString();
            // Retreives json-string from api url with query
            var apiStringResponse = new WebClient().DownloadString(apiUrl + query);

            var apiResponse = JsonConvert.DeserializeObject<Dictionary<string, List<JsonNamesModel>>>(apiStringResponse);
            // Used to convert the json string into model JsonModel
            //List<JsonModel> apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonModel>(apiStringResponse);
            //JObject test = JObject.Parse(apiStringResponse);

            return apiResponse;
        }

        /// <summary>
        /// Creates a NameModel List and populates it with the apiResponse parameter
        /// </summary>
        /// <param name="apiResponse"></param>
        private static List<NameModel> PopulateNameModelList(Dictionary<string, List<JsonNamesModel>> apiResponse)
        {
            // creates list to be returned
            List<NameModel> nameModelList = new List<NameModel>();

            foreach (var person in apiResponse["names"])
            {
                // Create NameModel object
                NameModel item = new NameModel();

                // Populate the item object with data from the current name iterated
                item.FirstName = person.firstname;
                item.LastName = person.surname;

                // Checks gender type
                switch (person.gender)
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
