using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace triggers_bindings_example
{
    public static class Example02
    {
        [FunctionName("Example02")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            [Blob("copied/{name}", FileAccess.Write, Connection = "scs")]Stream stream,
            ILogger log)
        {
            log.LogInformation("We're starting our simple copy action here!");
            // When using an Output binding, connecting to the storage account has been abstracted
            // away: you can simply use the Stream called 'stream' to write to.
            await addedBlob.CopyToAsync(stream);
        }
    }
}