using Refit;
using TmdbCollectorApi.Web.Models;

namespace TmdbCollectorApi.Web.Refit
{
    [Headers("Accept: application/json", "Authorization: Bearer")]
    public interface ITmdbApi
    {
        [Get("/search/person?query={name}")]
        Task<ActorList> GetActors(string name);

        [Get("/person/{actorId}/movie_credits?language=en-US")]
        Task<TmdbMovieList> GetMovies(int actorId);
    }
}
