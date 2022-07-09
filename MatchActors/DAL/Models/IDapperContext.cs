using System.Data;

namespace MatchActors.DAL.Models
{
    /// <summary>
    /// Подключение к БД
    /// </summary>
    public interface IDapperContext : IDisposable
    {
        /// <summary>
        /// Создать подключение
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IDbConnection> CreateConnection(CancellationToken cancellationToken);
    }
}
