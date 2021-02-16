using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using FinStats.Models;

namespace FinStats
{
    public class StocksQuery
    {
        public static async Task<List<Stock>> LatestStockAsync(AppDb db)
        {
            using var cmd = db.Connection.CreateCommand();

            cmd.CommandText = @"SELECT High, Low FROM STOCK ORDER BY Date DESC LIMIT 100;";

            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private static async Task<List<Stock>> ReadAllAsync(DbDataReader reader)
        {
            var stocks = new List<Stock>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var stock = new Stock()
                    {
                        High = reader.GetFloat(0),
                        Low = reader.GetFloat(1),
                    };

                    stocks.Add(stock);
                }
            }

            return stocks;
        }
    }
}
