using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;

namespace AksExample
{
    public class PingService : IPingService
    {
        private readonly ILogger<PingService> _logger;
        private readonly IHostIdProvider _hostIdProvider;

        public PingService(ILogger<PingService> logger, IHostIdProvider hostIdProvider)
        {
            _logger = logger;
            _hostIdProvider = hostIdProvider;
        }

        public async Task<string> Ping(CancellationToken cancellationToken)
        {
            _logger.LogInformation("We are pinged.");

            var hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken);
            var when = DateTime.UtcNow.ToString("O");
            return $"Pong from AKS - {hostId} at {when}!";
        }
    }
}