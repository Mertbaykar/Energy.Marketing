using Marketing.EF.Core;
using Marketing.Shared.HttpClients;
using Microsoft.EntityFrameworkCore;

namespace Marketing.ScheduledTasks
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDbContextFactory<MarketingContext> _dbContextFactory;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly SmpClient _smpClient;
        public Worker(IDbContextFactory<MarketingContext> dbContextFactory, ILogger<Worker> logger, IHostApplicationLifetime applicationLifetime, SmpClient smpClient)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
            _applicationLifetime = applicationLifetime;
            _smpClient = smpClient;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service has started at: {time}" + DateTime.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTime.Now);

                try
                {
                    using (MarketingContext context = _dbContextFactory.CreateDbContext())
                    {
                        var serviceRunner = new ServiceRunner(context);
                        await serviceRunner.RunServicesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Program has failed: " + ex.Message);
                }
                finally
                {
                    _applicationLifetime.StopApplication();
                }
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Application stopped at " + DateTime.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}