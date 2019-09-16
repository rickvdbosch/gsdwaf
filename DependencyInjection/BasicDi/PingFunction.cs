using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BasicDi
{
    public class PingFunction
    {
        private readonly IPingService _pingService;
        private readonly ILogger _logger;

        public PingFunction(IPingService pingService, ILogger<PingFunction> logger)
        {
            _pingService = pingService;
            _logger = logger;
        }

        [FunctionName(nameof(Ping))]
        public async Task<string> Ping(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entered function.");
            return await _pingService.Ping(cancellationToken);
        }
    }
}
 