using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using TriggersBindingsExample.Classes;

namespace TriggersBindingsExample
{
    public static class Example05
    {
        [FunctionName("Example05")]
        [return: Blob("copied/{sys.randguid}.txt", Connection = "scs")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] RequestModel req,
            ILogger log)
        {
            return req.Message;
        }
    }
}