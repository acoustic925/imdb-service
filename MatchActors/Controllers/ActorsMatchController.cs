using Dapper;
using MatchActors.Models;
using MatchActors.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Net;

namespace MatchActors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsMatchController : ControllerBase
    {
        private readonly IActorsMatchService _matchService;
        private readonly ILogger<ActorsMatchController> _logger;

        public ActorsMatchController(IActorsMatchService matchService, ILogger<ActorsMatchController> logger)
        {
            _matchService = matchService;
            _logger = logger;
        }

        /// <summary>
        /// Получить совместные фильмы для актеров
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("match_actors")]
        [ProducesResponseType(typeof(ActorsMatchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.GatewayTimeout)]
        public async Task<IActionResult> Post(ActorsMatchRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FirstActor) || string.IsNullOrEmpty(request.SecondActor))
                return Ok(new ActorsMatchResponse());

            try
            {
                var movies = await _matchService.GetMatchedMoviesAsync(request, cancellationToken);

                return Ok(new ActorsMatchResponse
                {
                    Results = movies
                });
            }
            catch(ActorsMatchException ex)
            {
                _logger.LogError($"Imdb service error: {ex.Message}");

                return StatusCode((int)HttpStatusCode.GatewayTimeout, new() { });
            }
        }
    }
}
