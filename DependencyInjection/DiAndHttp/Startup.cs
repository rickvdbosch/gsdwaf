using System;
using DiAndHttp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

[assembly: FunctionsStartup(typeof(Startup))]

namespace DiAndHttp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddOptions<PingSettings>()
                .Configure<IConfiguration>((configSection, configuration) =>
                {
                    configuration.Bind(configSection);
                });

            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient("PingClient")
                .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(5, retry => retry * TimeSpan.FromSeconds(1)));

            builder.Services.AddScoped<IPingInvokeService, PingInvokeService>();
        }
    }
}