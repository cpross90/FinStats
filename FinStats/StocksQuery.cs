using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace FinStats
{
    public class StocksQuery
    {
        public StocksQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<Stock>> LatestStockAsync()
        {
            using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = @"SELECT Date, Open, High, Low, Close, Adj_Close, Volume FROM STOCK ORDER BY Date DESC LIMIT 10;";

            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Stock>> ReadAllAsync(DbDataReader reader)
        {
            var stocks = new List<Stock>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var stock = new Stock(Db)
                    {
                        Date = reader.GetDateTime(0),
                        Open = reader.GetFloat(1),
                        High = reader.GetFloat(2),
                        Low = reader.GetFloat(3),
                        Close = reader.GetFloat(4),
                        Adj_Close = reader.GetFloat(5),
                        Volume = reader.GetFloat(6)

                    };

                    stocks.Add(stock);
                }
            }

            return stocks;
        }

        public AppDb Db { get; }
    }
}
