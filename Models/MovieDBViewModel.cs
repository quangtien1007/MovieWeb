using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Movie.Models
{
    [Keyless]
    public class MovieDBViewModel
    {
        public class MovieData
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("email")]
            public string email { get; set; }
            /*[JsonProperty("address")]
            public List<Address> address { get; set; }*/
            [JsonProperty("phone")]
            public string phone { get; set; }
            [JsonProperty("website")]
            public string website { get; set; }
            /*[JsonProperty("company")]
            public List<Company> company { get; set; }*/
        }

        public class Address
        {
            [JsonProperty("street")]
            public string street { get; set; }
            [JsonProperty("suite")]
            public string suite { get; set; }
            [JsonProperty("city")]
            public string city { get; set; }
            [JsonProperty("zipcode")]
            public string zipcode { get; set; }
            [JsonProperty("geo")]
            public List<Geo> geo { get; set; }
        }

        public class Company
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("catchPhrase")]
            public string catchPhrase { get; set; }
            [JsonProperty("bs")]
            public string bs { get; set; }
        }
        
        public class Geo
        {
            [JsonProperty("lat")]
            public double lat { get; set; }
            [JsonProperty("lng")]
            public double lng { get; set; }
        }
    }
}
