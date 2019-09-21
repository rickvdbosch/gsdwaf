using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace DependencyInjectionExample.Example04
{
    public class Function
    {
        private readonly IPingInvokeService _pingInvokeService;

        public Function(IPingInvokeService pingInvokeService)
        {
            _pingInvokeService = pingInvokeService;
        }

        [FunctionName(nameof(InvokePongTimer))]
        public async Task InvokePongTimer([TimerTrigger("*/15 * * * * *", RunOnStartup = false)]
            TimerInfo myTimer)
        {
            await _pingInvokeService.InvokePing();
        }
    }
}
