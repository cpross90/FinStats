using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

using FinStats.Models;
using System.Text.Json;

namespace FinStats.Data
{
    public class Update : IHostedService
    {
        readonly AppDb Db;
        readonly Finnhub API;
        List<string> Subscriptions;
        public Update(AppDb db, Finnhub api)
        {
            Db = db;
            API = api;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            StartWebSocket(); 

            return Task.CompletedTask;
        }
        private async void StartWebSocket()
        {
            await SetupConnection();
            await CreateChannel();
        }
        private async Task SetupConnection()
        {
            await API.Connection.StartAsync();

            LoadSubscriptions();

            foreach (var sub in Subscriptions)
            {
                // Need to convert to JSON
                //await API.Connection.SendAsync("send", );
            }
        }
        private async void LoadSubscriptions()
        {
            await Db.Connection.OpenAsync();

            Subscriptions = await StocksQuery.TickerSymbols(Db);

            await Db.Connection.CloseAsync();
        }
        private async Task CreateChannel()
        {
            var channel = await API.Connection.StreamAsChannelAsync<StockAPI>("message", CancellationToken.None);

            while(channel.TryRead(out var stock))
            {
                await Db.Connection.OpenAsync();

                var result = await StocksQuery.UpdateLatestAsync(Db, stock);

                System.Console.Error.WriteLine($"SQL write operation return code: {result}");

                await Db.Connection.CloseAsync();
            }
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {

            return Task.CompletedTask;
        }
    }
}