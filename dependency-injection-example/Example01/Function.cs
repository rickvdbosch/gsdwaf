using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionExample.Example01
{
    public static class Function
    {
        [FunctionName(nameof(Ping01))]
        public static async Task<string> Ping01(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var pingService = new PingService(log);

            return await pingService.Ping(cancellationToken); 
        }
    }
}
