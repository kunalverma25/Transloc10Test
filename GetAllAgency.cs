using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;

namespace Transloc10Test
{
    class GetAllAgency
    {
        
        public static async Task<RootObject> GetAll()
        {
            var file = checkFile();
            if (file == false)
            {
                string URL = "https://transloc-api-1-2.p.mashape.com/agencies.json";
                string urlParams = "";
                HttpClient client = new HttpClient();

                // Add headers for JSON format.
                client.BaseAddress = new Uri(URL, UriKind.Absolute);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "y1ussTz5ltmshVQrmpOiaCRBkpxip1zmwU3jsnX2QyR0SA2QaH");
                var respose = await client.GetAsync(urlParams);
                string result = await respose.Content.ReadAsStringAsync();
                storeInMem(result);
            }
            string result1 = ReadTextFile();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result1));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
            
        }

        

        static bool checkFile()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("agencies"))
                return true;
            else
                return false;
        }

        static void storeInMem(string result)
        {
            var localSettings = ApplicationData.Current.LocalSettings;

            // Create a simple setting

            localSettings.Values["agencies"] = result;

            // Read data from a simple setting

        }

        //static async Task<string> readFromMem()


        
        public static string ReadTextFile()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            string value = (String)localSettings.Values["agencies"];
            return value;
        }


        public static async Task<RootObject> GetClose(double lat, double lon, int rad = 75)
        {
            string URL = "https://transloc-api-1-2.p.mashape.com/agencies.json";
            string urlParams = (String)String.Format("?geo_area={0}%2C+{1}%7C{2}", lat.ToString(), lon.ToString(), rad.ToString());
            HttpClient client = new HttpClient();

            // Add headers for JSON format.
            client.BaseAddress = new Uri(URL, UriKind.Absolute);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "y1ussTz5ltmshVQrmpOiaCRBkpxip1zmwU3jsnX2QyR0SA2QaH");
            var respose = await client.GetAsync(urlParams);
            var result = await respose.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]
    public class Position
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lng { get; set; }
    }

    [DataContract]
    public class Datum
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]        
        public string short_name { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public string agency_id { get; set; }
        [DataMember]
        public string long_name { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public Position position { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public int rate_limit { get; set; }
        [DataMember]
        public int expires_in { get; set; }
        [DataMember]
        public string api_latest_version { get; set; }
        [DataMember]
        public string generated_on { get; set; }
        [DataMember]
        public List<Datum> data { get; set; }
        [DataMember]
        public string api_version { get; set; }
    }
}