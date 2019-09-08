using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiAndHttp
{
    public class PingInvokeService : IPingInvokeService
    {
        private readonly PingSettings _pingSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public PingInvokeService(IHttpClientFactory httpClientFactory, IOptions<PingSettings> options, ILogger<PingInvokeFunction> logger)
        {
            _pingSettings = options.Value;

            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task InvokePing()
        {
            var client = _httpClientFactory.CreateClient("PingClient");

            _logger.LogInformation("Pinging to [{url}].", _pingSettings.PingUrl);

            var responseMessage = await client.GetAsync(_pingSettings.PingUrl);
            responseMessage.EnsureSuccessStatusCode();
            var message = await responseMessage.Content.ReadAsStringAsync();

            _logger.LogInformation("Ping returned: [{message}].", message);
        }
    }
}