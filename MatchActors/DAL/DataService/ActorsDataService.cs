using Dapper;
using MatchActors.DAL.Models;

namespace MatchActors.DAL.DataService
{
    /// <inheritdoc/>
    /// 
    public class ActorsDataService : IActorsDataService
    {
        private readonly IDapperContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ActorsDataService(IDapperContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        ///
        public async Task AddActorAsync(string actorName, string actorId, CancellationToken cancellationToken)
        {
            using var connection = await _context.CreateConnection(cancellationToken);

            await connection.ExecuteAsync(@"insert into actors values(@ActorName, @ActorId);", new { ActorName = actorName.ToLower(), ActorId = actorId });
        }

        /// <inheritdoc/>
        ///
        public async Task<string> GetActorIdAsync(string actorName, CancellationToken cancellationToken)
        {
            using var connection = await _context.CreateConnection(cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<string>(@"select actor_id from actors where name=@ActorName;", new { ActorName = actorName.ToLower() });
        }
    }
}
