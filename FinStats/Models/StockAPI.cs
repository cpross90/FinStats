using System;
using System.Collections.Generic;

namespace FinStats.Models
{
    public class StockAPI
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Volume { get; set; }
        public List<string> Conditions { get; set; }
    }
}
