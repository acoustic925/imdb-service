namespace MatchActors.Infrastructure.MoviesService
{
    /// <summary>
    /// Ответ сервиса поиска фильмов по актеру Imdb
    /// </summary>
    public class ImdbMoviesResponse
    {
        /// <summary>
        /// Фильмы в которых участвовал актер
        /// </summary>
        public IEnumerable<MovieResponse> CastMovies { get; set; }
    }

    /// <summary>
    /// Сущность фильма, в котором снимался актер
    /// </summary>
    public class MovieResponse
    {
        /// <summary>
        /// Идентификатор фильма
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Роль в фильме
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Title { get; set; }
    }
}
