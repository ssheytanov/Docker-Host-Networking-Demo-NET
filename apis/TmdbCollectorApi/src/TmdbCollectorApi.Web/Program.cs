
using Refit;
using TmdbCollectorApi.Web.MappingConfiguration;
using TmdbCollectorApi.Web.Refit;

namespace TmdbCollectorApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            TmdbSettings? tmdbSettings = builder.Configuration.GetRequiredSection("Tmdb").Get<TmdbSettings>();

            RefitSettings refitSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = (rq, ct) => Task.FromResult(tmdbSettings?.ApiKey),
            };

            builder.Services
                .AddRefitClient<ITmdbApi>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(tmdbSettings?.ApiUrl));

            builder.Services.AddAutoMapper(typeof(TmdbMappingConfiguration));

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
