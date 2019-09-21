using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionExample.Example01
{
    public class PingService : IPingService
    {
        private readonly ILogger _logger;

        public PingService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> Ping(CancellationToken cancellationToken)
        {
            _logger.LogInformation("We are pinged.");

            var when = DateTime.UtcNow.ToString("O");
            return await Task.FromResult($"Pong at {when}.");
        }
    }
}