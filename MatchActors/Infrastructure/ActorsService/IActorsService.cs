namespace MatchActors.Infrastructure.ActorsService
{
    /// <summary>
    /// Сервис для работы с актерами
    /// </summary>
    public interface IActorsService
    {
        /// <summary>
        /// Получить идентификатор актера
        /// </summary>
        /// <param name="actorName"></param>
        /// <returns></returns>
        Task<string> GetActorIdAsync(string actorName, CancellationToken cancellationToken);
    }
}
