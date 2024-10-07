using AutoMapper;
using TmdbCollectorApi.Web.Models;
using TmdbCollectorApi.Web.ResponseModels;

namespace TmdbCollectorApi.Web.MappingConfiguration
{
    public class TmdbMappingConfiguration : Profile
    {
        public TmdbMappingConfiguration()
        {
            this.CreateMap<TmdbMovieList, MovieList>();
            this.CreateMap<TmdbMovie, Movie>();
        }
    }
}
