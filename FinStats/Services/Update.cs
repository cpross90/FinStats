using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using FinStats.Models;
using System.Collections.Generic;

namespace FinStats.Services
{
    public class Update : IHostedService, IDisposable
    {
        private Timer _timer;
        public AppDb Db { get; }

        public Update(AppDb db)
        {
            Db = db;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {   /*It is set to five seconds. Way later when you can look
            *into changing it to a different time metric
            */
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            // Assume result is of type List<stock>
            var result = CallQuery();

        }

        private async Task<List<Stock>> CallQuery()
        {
            await Db.Connection.OpenAsync();
            var result = await StocksQuery.LatestStockAsync(Db);
            await Db.Connection.CloseAsync();

            return result;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
