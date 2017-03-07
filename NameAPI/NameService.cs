using System.Collections.Generic;
using System.Net;
using NameAPI.Models;
using Newtonsoft.Json;

namespace NameAPI
{
    /// <summary>
    /// List names; NameModel as model 
    /// </summary>
    public class JsonModel
    {
        public string firstname;
        public string surname;
        public string gender;
    }

    public class JsonModelName
    {
        public List<JsonModel> names;
    }

    /// <summary>
    /// Class that handles the query string
    /// </summary>
    public class QueryValues
    {
        public static string limit = "10";
        public static string type = "both";
        public static string gender = "both";
        
        private static string query;

        /// <summary>
        /// Constructor calls setQueryString()
        /// </summary>
        public QueryValues()
        {
            setQueryString();
        }

        /// <summary>
        /// Overrides current query string
        /// </summary>
        private static void setQueryString()
        {
            query = "?limit=" + limit + "&type=" + type + "&gender=" + gender;
        }

        /// <summary>
        /// Returns the current query string
        /// </summary>
        /// <returns>string</returns>
        public static string getQueryString()
        {
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
            QueryValues.limit = limit.ToString();
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
            QueryValues.type = type.ToString();
            QueryValues.limit = limit.ToString();
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
            QueryValues.gender = gender.ToString();
            QueryValues.limit = limit.ToString();
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
            QueryValues.type = type.ToString().ToLower();
            QueryValues.gender = gender.ToString().ToLower();
            QueryValues.limit = limit.ToString();
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
            JsonModelName apiResponse = GetApiResponse();

            // Go through all name-objects and populate the list
            List<NameModel> nameList = PopulateNameModelList(apiResponse);
            return nameList;
        }

        /// <summary>
        /// Gets query string and makes api call. Then converts the string from api call into a List object
        /// </summary>
        private static JsonModelName GetApiResponse()
        {
            string query = QueryValues.getQueryString();
            // Retreives json-string from api url with query
            var apiStringResponse = new WebClient().DownloadString(apiUrl + query);

            JsonModelName apiResponse = JsonConvert.DeserializeObject<JsonModelName>(apiStringResponse);
            // Used to convert the json string into model JsonModel
            //List<JsonModel> apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonModel>(apiStringResponse);
            //JObject test = JObject.Parse(apiStringResponse);

            return apiResponse;
        }

        /// <summary>
        /// Creates a NameModel List and populates it with the apiResponse parameter
        /// </summary>
        /// <param name="apiResponse"></param>
        private static List<NameModel> PopulateNameModelList(JsonModelName apiResponse)
        {
            // creates list to be returned
            List<NameModel> nameModelList = new List<NameModel>();

            // Goes through alla names from the api response
            foreach (var name in apiResponse.names)
            {
                // Create NameModel object
                NameModel item = new NameModel();

                // Populate the item object with data from the current name iterated
                item.FirstName = name.firstname;
                item.LastName = name.surname;

                // Checks gender type
                switch (name.gender)
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
