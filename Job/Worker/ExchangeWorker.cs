using Hangfire;
using Job.Worker.Worker;

namespace Job.Worker
{
    public class ExchangeWorker : BackgroundService
    {
        private readonly ILogger<ExchangeWorker> _logger;

        public ExchangeWorker(ILogger<ExchangeWorker> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RecurringJob.AddOrUpdate<ExchangeRateJob>(
                "fetch-usd-rates-hourly",
                job => job.FetchAndUpsertAsync("USD"),
                //Cron.Minutely
                Cron.Hourly
                );

            return Task.CompletedTask;
        }
    }
}
