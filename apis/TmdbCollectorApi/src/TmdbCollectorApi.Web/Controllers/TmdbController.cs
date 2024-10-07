using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TmdbCollectorApi.Web.Models;
using TmdbCollectorApi.Web.Refit;
using TmdbCollectorApi.Web.ResponseModels;

namespace RatingsGatherer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmdbController(ITmdbApi tmdbApi, IMapper mapper) : ControllerBase
    {
        private readonly ITmdbApi tmdbApi = tmdbApi;
        private readonly IMapper mapper = mapper;

        [HttpGet("actors/")]
        public async Task<ActorList> GetActors([FromQuery][Required] string name)
        {
            var response = await this.tmdbApi.GetActors(name);

            return response;
        }

        [HttpGet("actors/{actorId}/movies")]
        public async Task<MovieList> GetMovies(int actorId)
        {
            var response = await this.tmdbApi.GetMovies(actorId);

            return this.mapper.Map<MovieList>(response);
        }
    }
}
