using System;
using MySqlConnector;

namespace FinStats.Data
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection { get; }
        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
        public async void Dispose()
        {
            await Connection.DisposeAsync();

            GC.SuppressFinalize(this);
        }
    }
}
