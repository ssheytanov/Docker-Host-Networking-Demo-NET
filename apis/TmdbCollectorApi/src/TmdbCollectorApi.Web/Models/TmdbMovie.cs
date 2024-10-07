using System.Text.Json.Serialization;

namespace TmdbCollectorApi.Web.Models
{
    public class TmdbMovie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
    }
}
