using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pras.Shared.Helpers
{
    public class IPGeographicalLocation
    {
        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("countryCode")]

        public string CountryCode { get; set; }

        [JsonProperty("country")]

        public string CountryName { get; set; }

        [JsonProperty("region")]

        public string RegionCode { get; set; }

        [JsonProperty("regionName")]

        public string RegionName { get; set; }

        [JsonProperty("city")]

        public string City { get; set; }

        [JsonProperty("zip")]

        public string ZipCode { get; set; }

        [JsonProperty("timezone")]

        public string TimeZone { get; set; }

        [JsonProperty("lat")]

        public float Latitude { get; set; }

        [JsonProperty("lon")]

        public float Longitude { get; set; }
        
        private IPGeographicalLocation() { }

        public static async Task<IPGeographicalLocation> QueryGeographicalLocationAsync(string ipAddress)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://ip-api.com/json/" + ipAddress);

            return JsonConvert.DeserializeObject<IPGeographicalLocation>(result);
        }
    }
}
