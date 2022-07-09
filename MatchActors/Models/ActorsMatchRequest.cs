namespace MatchActors.Models
{
    /// <summary>
    /// Запрос на получение фильмов
    /// </summary>
    public class ActorsMatchRequest
    {
        /// <summary>
        /// Имя первого актера
        /// </summary>
        public string FirstActor { get; set; }

        /// <summary>
        /// Имя второго актера
        /// </summary>
        public string SecondActor { get; set; }

        /// <summary>
        /// Флаг поиска только по фильмам
        /// </summary>
        public bool? MoviesOnly { get; set; }
    }
}
