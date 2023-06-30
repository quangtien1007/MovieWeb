using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Movie.Models
{
    [Keyless]
    public class MovieDBViewModel
    {
        public class MovieData
        {
            [JsonProperty("page")]
            public int page { get; set; }
            [JsonProperty("results")]
            public List<Movie> movie { get; set; }
            [JsonProperty("total_page")]
            public int total_page { get; set; }
            [JsonProperty("total_results")]
            public int total_results { get; set; }
        }

        public class Movie
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("original_title")]
            public string original_title { get; set; }
            [JsonProperty("overview")]
            public string overview { get; set; }
            [JsonProperty("popularity")]
            public int popularity { get; set; }
            [JsonProperty("release_date")]
            public DateTime release_date { get; set; }
            [JsonProperty("vote_average")]
            public double vote_average { get; set; }
        }
        
    }
}
