using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;

namespace BasicDi
{
    public class PingService : IPingService
    {
        private readonly ILogger _logger;
        private readonly IHostIdProvider _hostIdProvider;

        public PingService(ILogger<PingService> logger, IHostIdProvider hostIdProvider)
        {
            _logger = logger;
            _hostIdProvider = hostIdProvider;
        }

        public async Task<string> Ping(CancellationToken cancellationToken)
        {
            _logger.LogInformation("We are pinged.");

            return await Task.FromResult($"Pong from {await _hostIdProvider.GetHostIdAsync(CancellationToken.None)}");
        }
    }
}