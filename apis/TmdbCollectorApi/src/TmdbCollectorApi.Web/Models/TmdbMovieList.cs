using System.Text.Json.Serialization;

namespace TmdbCollectorApi.Web.Models
{
    public class TmdbMovieList
    {
        [JsonPropertyName("cast")]
        public List<TmdbMovie> Movies { get; set; }
    }
}
