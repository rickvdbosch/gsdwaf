using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace DiAndHttp
{
    public class PingInvokeFunction
    {
        private readonly IPingInvokeService _pingInvokeService;

        public PingInvokeFunction(IPingInvokeService pingInvokeService)
        {
            _pingInvokeService = pingInvokeService;
        }

        [FunctionName(nameof(InvokePongTimer))]
        public async Task InvokePongTimer([TimerTrigger("*/30 * * * * *", RunOnStartup = true)]TimerInfo myTimer)
        {
            await _pingInvokeService.InvokePing();
        }
    }
}
