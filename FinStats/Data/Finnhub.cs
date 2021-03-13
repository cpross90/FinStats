using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace FinStats.Data
{
    public class Finnhub : IDisposable
    {
        public HubConnection Connection { get; }
        private readonly string Token;

        public Finnhub(string connectionString, string token)
        {
            Connection = new HubConnectionBuilder()
                .WithUrl(new Uri(connectionString), options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(Token);
                    options.Transports = HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect()
                .Build();

            Token = token;
        }
        public async void Dispose()
        {
            await Connection.DisposeAsync();

            GC.SuppressFinalize(this);
        }
    }
}
