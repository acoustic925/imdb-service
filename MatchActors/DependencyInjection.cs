using MatchActors.DAL.DataService;
using MatchActors.DAL.Models;
using MatchActors.Infrastructure;
using MatchActors.Infrastructure.ActorsService;
using MatchActors.Infrastructure.MoviesService;
using MatchActors.Services;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace MatchActors
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var imdbOptions = configuration.GetSection("ImdbOptions");
            services.Configure<ImdbOptions>(imdbOptions);

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TimeoutRejectedException>() 
                .Or<TaskCanceledException>() 
                .WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
                    });

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            services.AddHttpClient("imdb-client", (provider, client) =>
            {
                var options = provider.GetService<IOptions<ImdbOptions>>()?.Value
                       ?? throw new ArgumentNullException(nameof(ImdbOptions));
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(options.RequestTimeout ?? 30);
            })
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(timeoutPolicy);

            services.AddSingleton<IDapperContext, DapperContext>();
            services.AddTransient<IActorsDataService, ActorsDataService>();
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IActorsMatchService, ActorsMatchService>();

            return services;
        }
    }
}
