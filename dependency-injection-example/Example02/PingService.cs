using System;
using System.Threading;
using System.Threading.Tasks;
using DependencyInjectionExample.Example01;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionExample.Example02
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
            return $"Pong from {hostId} at {when}.";
        }
    }
}