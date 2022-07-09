using MatchActors.Models;

namespace MatchActors.Services
{
    /// <summary>
    /// Сервис обертка для логики матча актеров
    /// </summary>
    public interface IActorsMatchService
    {
        /// <summary>
        /// Получить совместные фильмы 
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<string>> GetMatchedMoviesAsync(ActorsMatchRequest request, CancellationToken cancellationToken);
    }
}
