using ApiGateway.Web.Models;
using Refit;

namespace ApiGateway.Web.Refit
{
    public interface ITmdbCollectorApi
    {
        [Get("/api/Tmdb/actors/{actorId}/movies")]

        public Task<MovieList> GetMovies(int actorId);
    }
}
