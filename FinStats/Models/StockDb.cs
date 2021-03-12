using System;

namespace FinStats.Models
{
    public class StockDb
    {
        public string Ticker { get; set; }

        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Volume { get; set; }
    }
}
