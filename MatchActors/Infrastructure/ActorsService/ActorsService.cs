using Dapper;
using MatchActors.DAL.DataService;
using MatchActors.DAL.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MatchActors.Infrastructure.ActorsService
{
    /// <inheritdoc/>
    /// 
    public class ActorsService : IActorsService
    {
        private readonly IActorsDataService _dataService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ImdbOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="clientFactory"></param>
        /// <param name="options"></param>
        public ActorsService(IHttpClientFactory clientFactory, IOptionsSnapshot<ImdbOptions> options, IActorsDataService dataService)
        {
            _clientFactory = clientFactory;
            _options = options.Value;
            _dataService = dataService;
        }

        /// <inheritdoc/>
        /// 
        public async Task<string> GetActorIdAsync(string actorName, CancellationToken cancellationToken)
        {
            var actorId = await _dataService.GetActorIdAsync(actorName, cancellationToken);

            if (actorId is not null)
                return actorId;

            actorId = await GetActorIdFromImdbAsync(actorName, cancellationToken);

            if(actorId is not null)
                await _dataService.AddActorAsync(
                    actorName: actorName,
                    actorId: actorId,
                    cancellationToken: cancellationToken);

            return actorId;
        }          
     
        /// <summary>
        /// Получить идентификатор актера из API IMBD
        /// </summary>
        /// <param name="actorName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<string> GetActorIdFromImdbAsync(string actorName, CancellationToken cancellationToken)
        {
            using var client = _clientFactory.CreateClient("imdb-client");

            using var response = await client.GetAsync($"{_options.ActorsPath}/{_options.ApiKey}/{actorName}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var data = JsonConvert.DeserializeObject<ImdbActorsResponse>(content);

            return data.Results?.FirstOrDefault(x => x.Title == actorName)?.Id;
        }
    }
}
