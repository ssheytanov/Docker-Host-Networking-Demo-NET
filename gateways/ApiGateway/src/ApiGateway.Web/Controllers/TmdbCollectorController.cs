using ApiGateway.Web.Models;
using ApiGateway.Web.Refit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmdbCollectorController(ITmdbCollectorApi tmdbCollectorApi) : ControllerBase
    {
        private readonly ITmdbCollectorApi tmdbCollectorApi = tmdbCollectorApi;

        [HttpGet("actors/{actorId}/movies")]
        public async Task<MovieList> GetMovies(int actorId)
        {
            var response = await tmdbCollectorApi.GetMovies(actorId);

            return response;
        } 
    }
}
