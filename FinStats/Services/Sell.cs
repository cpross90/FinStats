using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinStats.Services
{
    public class Sell
    {
        public static bool TimeToSell(List<double> myHigh, List<double> myLow, double price)
        {
            int len=myLow.Count;
            int len_4 = len / 4;
            int len_50 = len / 2;
            int len_75 = 3 * len / 4;
            List<double> myHigh_1 = Maxmin.FindTheMax(myHigh.GetRange(0,len_4));
            double M = myHigh_1.Max();
            //Figure this 1.05 out. I know 105% but still see if it good in unit testing
            bool v = ((1.05*price) <= M | M==0);
            if (v)
            {
            return !v;
            }
            List<double> myLow_1 = Maxmin.FindTheMin(myLow.GetRange((len_4-1),len_4));
            double L = myLow_1.Min();
            v = (price <= L | L==0);
            if (v)
            {
            return !v;
            }
            myHigh_1 = Maxmin.FindTheMax(myHigh.GetRange((len_50 - 1), len_4));
            double W = myHigh_1.Max();
            v = (M <= W);
            if(v)
            {
            return !v;
            }
            myLow_1 = Maxmin.FindTheMin(myLow.GetRange((len_75 - 1), len_4));
            //double S = myLow.Min(); look into this one again
            double R = myLow_1.Min();
            //Fix the V formula to make a 10% loss with 15% margin of error
            v = (R < (0.75 * price) && R!=0);
            return v;
        }
    }
}
