using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TriggersBindingsExample.Classes;

namespace TriggersBindingsExample
{
    public static class Example05
    {
        [FunctionName("Example05")]
        [return: Blob("copied/{sys.randguid}.txt", Connection = "scs")]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            using (var reader = new StreamReader(req.Body))
            {
                var model = JsonConvert.DeserializeObject<RequestModel>(await reader.ReadToEndAsync());

                return model.Message;
            }
        }
    }
}