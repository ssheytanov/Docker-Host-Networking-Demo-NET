using System.Text.Json.Serialization;

namespace TmdbCollectorApi.Web.Models
{
    public class ActorList
    {
        [JsonPropertyName("results")]
        public List<Actor> Actors { get; set; }
    }
}
