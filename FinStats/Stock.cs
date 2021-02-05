using System;

namespace FinStats
{
    public class Stock
    {
        public Stock(AppDb db)
        {
            Db = db;
        }

        internal AppDb Db { get; set; }

        public DateTime Date { get; set; }

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public double Adj_Close { get; set; }

        public double Volume { get; set; }
    }
}
