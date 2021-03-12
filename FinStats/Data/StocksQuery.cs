using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

using FinStats.Models;

namespace FinStats.Data
{
    public class StocksQuery
    {
        public static async Task<List<string>> TickerSymbols(AppDb db)
        {
            using var cmd = db.Connection.CreateCommand();

            cmd.CommandText = @"SELECT symbol FROM Stocks ORDER BY symbol ASC;";

            return await ReadSymbolAsync(await cmd.ExecuteReaderAsync());
        }
        private static async Task<List<string>> ReadSymbolAsync(DbDataReader reader)
        {
            var stocks = new List<string>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    stocks.Add(reader.GetString(0));
                }
            }

            return stocks;
        }
        public static async Task<List<StockDb>> LatestAsync(AppDb db)
        {
            using var cmd = db.Connection.CreateCommand();

            cmd.CommandText = @"SELECT ticker, price FROM DailyStock ORDER BY Date DESC LIMIT 10;";

            return await ReadSymbolPriceAsync(await cmd.ExecuteReaderAsync());
        }
        private static async Task<List<StockDb>> ReadSymbolPriceAsync(DbDataReader reader)
        {
            var stocks = new List<StockDb>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var stock = new StockDb()
                    {
                        Ticker = reader.GetString(0),
                        Price = reader.GetDecimal(1)
                    };

                    stocks.Add(stock);
                }
            }

            return stocks;
        }
        public static async Task<int> UpdateLatestAsync(AppDb db, StockAPI stock)
        {
            using var cmd = db.Connection.CreateCommand();

            cmd.CommandText = $@"INSERT INTO DailyStock VALUES ({stock.Symbol}, {stock.Price}, {stock.Timestamp}, {stock.Volume});";

            return await cmd.ExecuteNonQueryAsync();
        }
    }
}
