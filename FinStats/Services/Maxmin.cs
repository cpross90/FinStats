using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinStats.Models;



namespace FinStats.Services
{

    class Maxmin
    {
        public static List<double> FindTheMin(List<double> listofStock)
        {
            /*High
             * Low
             * Date
             * find a way to get only one of three at a time
            */

            var min = listofStock.Min();
            int m_i = listofStock.ToList().IndexOf(listofStock.Min());
            int length = listofStock.Count();
            if (m_i != (length-1) && m_i !=0)
            {
                return listofStock;
            }
            else
            {
                List<double> bad = new List<double> {0.0};
                return bad;
            }
                
            
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
        public static List<double> FindTheMax(List<double> listofStock)
        {
            double max = listofStock.Max();
            int m_i = listofStock.ToList().IndexOf(max);
            int length = listofStock.Count();
            if (m_i != (length-1) && m_i != 0)
            {
                return listofStock;
            }
            else
            {
                List<double> bad = new List<double> { 0.0 };
                return bad;
            }
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
       
    }
}
