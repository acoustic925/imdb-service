namespace MatchActors.Infrastructure.MoviesService
{
    /// <summary>
    /// Сервис для работы с фильмами
    /// </summary>
    public interface IMoviesService
    {
        /// <summary>
        /// Получить совместные фильмы
        /// </summary>
        /// <param name="firstActorId">Идентификатор первого актера</param>
        /// <param name="secondActorId">Идентификатор второго актера</param>
        /// <param name="moviesOnly">Флаг поиска только по фильмам</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetJointMoviesAsync(string firstActorId, string secondActorId, bool? moviesOnly, CancellationToken cancellationToken);
    } 
}
