namespace MatchActors.Infrastructure
{
    /// <summary>
    /// Опции для подключения к Imdb сервисам
    /// </summary>
    public class ImdbOptions
    {
        /// <summary>
        /// Базовый путь
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Путь к api поиска актеров по имени
        /// </summary>
        public string ActorsPath { get; set; }

        /// <summary>
        /// Путь к api поиска фильмов по идентификаторам актеров
        /// </summary>
        public string MoviesPath { get; set; }

        /// <summary>
        /// Ключ идентификации Imdb API
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Таймаут запроса
        /// </summary>
        public int? RequestTimeout { get; set; }
    }
}
