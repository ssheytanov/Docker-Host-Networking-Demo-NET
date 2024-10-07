using System.ComponentModel.DataAnnotations;

namespace TmdbCollectorApi.Web.Refit
{
    public class TmdbSettings
    {
        [Required]
        public required string ApiKey { get; set; }

        [Required]
        [Url]
        public required string ApiUrl { get; set; }
    }
}