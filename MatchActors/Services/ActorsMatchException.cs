namespace MatchActors.Services
{
    /// <summary>
    /// Ошибка, пробрасывается, когда возникают проблемы с сервисами IMDB
    /// </summary>
    public class ActorsMatchException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ActorsMatchException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ActorsMatchException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ActorsMatchException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
