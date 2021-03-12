using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace FinStats.Data
{
    public class Finnhub : IDisposable
    {
        public HubConnection Connection { get; }

        public Finnhub(string connectionString)
        {
            Connection = new HubConnectionBuilder().WithUrl(new Uri(connectionString))
                .WithAutomaticReconnect()
                .Build();
        }
        public async void Dispose()
        {
            await Connection.DisposeAsync();

            GC.SuppressFinalize(this);
        }
    }
}
