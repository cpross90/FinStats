using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinStats.Services
{
    class Maxmin
    {
        public CallQuery()
        {


        }
        public static List<double> Findthemin(int length)
        {
            List<double> min = CallQuery();
            int m_i = min.ToList().IndexOf(min.Min());
            while (m_i == length | m_i ==0)
            { 
                min = CallQuery();
                m_i = min.ToList().IndexOf(min.Min());
            }
            return min;
            
            /*if (m_i == length)
            {
                min = StocksQuery();
            }
            else if (m_i == 0)
            {
                min = StocksQuery();
                //make half chopper
                return
            }
            else
            {
                return min;
            }
            */
        }
        public static List<double> Findthemax(int length)
        {
            List<double> max = Stock();
            int m_i = max.ToList().IndexOf(max.Max());
            while (m_i == length | m_i == 0)
            {
                max = Stock();
                m_i = max.ToList().IndexOf(max.Max());
            }
            return max; 
            /*
            if (m_i == 0)
            {
                max = StocksQuery();
            }
            else if (m_i == length)
            {
                //max = Halfchopper("High", max, length);
                return max;
            }
            else
            {
                return max;
            }
            */

        }
        private static List<double> Stock(AppDb db)
        {
            throw new NotImplementedException();
        }

    }
}
