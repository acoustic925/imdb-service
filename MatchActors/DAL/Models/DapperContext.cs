using Npgsql;
using System.Data;

namespace MatchActors.DAL.Models
{
    /// <inheritdoc/>
    /// 
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private NpgsqlConnection _connection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        /// 
        public async Task<IDbConnection> CreateConnection(CancellationToken cancellationToken)
        {
            if (_connection != null)
            {
                return _connection;
            }

            _connection = new NpgsqlConnection(_configuration.GetConnectionString("ActorsConnection"));
            await _connection.OpenAsync(cancellationToken);
            _connection.StateChange += (o, e) =>
            {
                if (e.CurrentState == ConnectionState.Closed)
                {
                    _connection = null;
                }
            };
            return _connection;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
