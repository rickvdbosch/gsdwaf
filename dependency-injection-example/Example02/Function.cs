using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace DependencyInjectionExample.Example02
{
    public class Function
    {
        private readonly IPingService _pingService;

        public Function(IPingService pingService)
        {
            _pingService = pingService;
        }

        [FunctionName(nameof(Ping02))]
        public async Task<string> Ping02(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            CancellationToken cancellationToken)
            => await _pingService.Ping(cancellationToken); 
    }
}
