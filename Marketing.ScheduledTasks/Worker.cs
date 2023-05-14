using Marketing.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Marketing.ScheduledTasks
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        IDbContextFactory<MarketingContext> _dbContextFactory;
        IHostApplicationLifetime _applicationLifetime;
        public Worker(IDbContextFactory<MarketingContext> dbContextFactory, ILogger<Worker> logger, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
            _applicationLifetime = applicationLifetime;
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
                        // TODO: marketing context'in constructor'a parametre olarak ge�ildi�i bir class olsun
                        // Execute edilme vakti gelmi� servisleri �ekip taskName'leri arac�l���yla gerekli methodlar� �al��t�ral�m
                    }
                    _applicationLifetime.StopApplication();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Program has failed: " + ex.Message);
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