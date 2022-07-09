namespace MatchActors.Infrastructure.ActorsService
{
    /// <summary>
    /// Ответ метода поиска актера по имени API IMBD
    /// </summary>
    public class ImdbActorsResponse
    {
        /// <summary>
        /// Результат запроса
        /// </summary>
        public IEnumerable<ActorResponse> Results { get; set; }
    }

    /// <summary>
    /// Dto актера
    /// </summary>
    public class ActorResponse
    {
        /// <summary>
        /// Идентификатор актера
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя актера
        /// </summary>
        public string Title { get; set; }
    }
}
