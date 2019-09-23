using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DependencyInjectionExample.Example04
{
    public class PingInvokeService : IPingInvokeService
    {
        private readonly PingSettings _pingSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PingInvokeService> _logger;

        public PingInvokeService(IHttpClientFactory httpClientFactory, IOptions<PingSettings> options, ILogger<PingInvokeService> logger)
        {
            _pingSettings = options.Value;

            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task InvokePing()
        {
            var client = _httpClientFactory.CreateClient("PingClient");
            var pingUrl = _pingSettings.PingUrl;

            _logger.LogInformation("Pinging to [{url}].", pingUrl);

            var responseMessage = await client.GetAsync(pingUrl);
            responseMessage.EnsureSuccessStatusCode();
            var message = await responseMessage.Content.ReadAsStringAsync();

            _logger.LogInformation("Ping returned: [{message}].", message);
        }
    }
}