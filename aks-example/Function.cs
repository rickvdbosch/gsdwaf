using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AksExample
{
    public class Function
    {
        private readonly IPingService _pingService;

        public Function(IPingService pingService)
        {
            _pingService = pingService;
        }

        [FunctionName(nameof(PingAks))]
        public async Task<string> PingAks(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            CancellationToken cancellationToken)
            => await _pingService.Ping(cancellationToken); 
    }
}
