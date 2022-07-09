using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MatchActors.Infrastructure.MoviesService
{
    /// <inheritdoc/>
    /// 
    public class MoviesService : IMoviesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ImdbOptions _options;
        private readonly List<string> _roles = new()
        {
            "actor",
            "actress"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientFactory"></param>
        /// <param name="options"></param>
        public MoviesService(IHttpClientFactory clientFactory, IOptionsSnapshot<ImdbOptions> options)
        {
            _clientFactory = clientFactory;
            _options = options.Value;
        }

        /// <inheritdoc/>
        /// 
        public async Task<IEnumerable<string>> GetJointMoviesAsync(string firstActorId, string secondActorId, bool? moviesOnly, CancellationToken cancellationToken)
        {
            var firstActorMovies = await GetActorMoviesAsync(firstActorId, moviesOnly, cancellationToken);
            var secondActorMovies = await GetActorMoviesAsync(secondActorId, moviesOnly, cancellationToken);

            var joinFilms = firstActorMovies.Join(secondActorMovies,
                x => x.Id,
                y => y.Id,
                (x,y) => x.Title);

            return joinFilms;
        }

        /// <summary>
        /// Получить фильмы актера
        /// </summary>
        /// <param name="actorId">Идентификатор актера</param>
        /// <param name="moviesOnly">Флаг поиска только по фильмам</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IEnumerable<MovieResponse>> GetActorMoviesAsync(string actorId, bool? moviesOnly, CancellationToken cancellationToken)
        {
            using var client = _clientFactory.CreateClient("imdb-client");

            using var response = await client.GetAsync($"{_options.MoviesPath}/{_options.ApiKey}/{actorId}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var data = JsonConvert.DeserializeObject<ImdbMoviesResponse>(content);

            if (moviesOnly == true)
                return data?.CastMovies.Where(x => _roles.Contains(x.Role.ToLower()));

            return data?.CastMovies;
        }
    }
}
