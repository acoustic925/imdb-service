namespace MatchActors.Models
{
    /// <summary>
    /// Ответ сервиса поиска фильмов по актерам
    /// </summary>
    public class ActorsMatchResponse
    {
        /// <summary>
        /// Результат поиска фильмов
        /// </summary>
        public IEnumerable<string> Results { get; set; }
    }
}
