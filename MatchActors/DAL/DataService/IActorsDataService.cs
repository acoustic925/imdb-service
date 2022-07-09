namespace MatchActors.DAL.DataService
{
    /// <summary>
    /// Сервис для работы с БД
    /// </summary>
    public interface IActorsDataService
    {
        /// <summary>
        /// Получить идентификатор актера из БД
        /// </summary>
        /// <param name="actorName">Имя актера</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetActorIdAsync(string actorName, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить актера в БД
        /// </summary>
        /// <param name="actorName">Имя актера</param>
        /// <param name="actorId">Идентификатор актера</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddActorAsync(string actorName, string actorId, CancellationToken cancellationToken);
    }
}
