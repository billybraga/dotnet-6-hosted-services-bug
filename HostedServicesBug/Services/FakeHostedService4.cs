using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedServicesBug.Services
{
    public class FakeHostedService4 : BackgroundService
    {
        private readonly ILogger<FakeHostedService4> logger;

        public FakeHostedService4(ILogger<FakeHostedService4> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogInformation("Still running");
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}