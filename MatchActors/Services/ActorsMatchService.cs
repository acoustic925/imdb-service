using MatchActors.Infrastructure.ActorsService;
using MatchActors.Infrastructure.MoviesService;
using MatchActors.Models;
using Newtonsoft.Json;

namespace MatchActors.Services
{
    /// <inheritdoc/>
    /// 
    public class ActorsMatchService : IActorsMatchService
    {
        private readonly IActorsService _actorsService;
        private readonly IMoviesService _moviesService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorsService"></param>
        /// <param name="moviesService"></param>
        public ActorsMatchService(IActorsService actorsService, IMoviesService moviesService)
        {
            _actorsService = actorsService;
            _moviesService = moviesService;
        }

        /// <inheritdoc/>
        ///
        public async Task<IEnumerable<string>> GetMatchedMoviesAsync(ActorsMatchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var firsActorId = await _actorsService.GetActorIdAsync(request.FirstActor, cancellationToken);
                var secondActorId = await _actorsService.GetActorIdAsync(request.SecondActor, cancellationToken);

                if (firsActorId is null || secondActorId is null)
                    return new List<string>();

                var movies = await _moviesService.GetJointMoviesAsync(
                    firstActorId: firsActorId,
                    secondActorId: secondActorId,
                    moviesOnly: request.MoviesOnly,
                    cancellationToken: cancellationToken);

                return movies;
            }
            catch (HttpRequestException ex)
            {
                throw new ActorsMatchException(ex.Message, ex);
            }
            catch (JsonSerializationException ex)
            {
                throw new ActorsMatchException(ex.Message, ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new ActorsMatchException(ex.Message, ex);
            } 
        }
    }
}
