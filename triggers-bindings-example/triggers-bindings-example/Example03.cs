using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace TriggersBindingsExample
{
    public static class Example03
    {
        [FunctionName("Example03")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            Binder binder, ILogger log)
        {
            log.LogInformation("Dynamic output binding");
            BlobAttribute blobAttribute;

            if (addedBlob.Length % 2 == 0)
            {
                // Create the BlobAttribute dynamically during Function execution
                blobAttribute = new BlobAttribute("even-length/{name}", FileAccess.Write);
            }
            else
            {
                // Create the BlobAttribute dynamically during Function execution
                blobAttribute = new BlobAttribute("odd-length/{name}", FileAccess.Write);
            }

            // Use the dynamically created binding to bind and then use the stream.
            using (var output = await binder.BindAsync<Stream>(blobAttribute))
            {
                await addedBlob.CopyToAsync(output);
            }
        }
    }
}
