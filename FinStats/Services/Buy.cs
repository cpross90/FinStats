using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinStats.Services
{
    public class Buy
    {
        public static bool TimeToBuy(List<double> myHigh, List<double> myLow)
        {
            int len = myHigh.Count;
            int len_4 = len / 4;
            int len_50 = (len / 2)-1;
            int len_75 = (3 * len / 4)-1;
            //myList.GetRange(50, 10)
            // Retrieves 10 items starting with index #50
            //remove max and min and use database idea!
            List<double> myHigh1 = Maxmin.FindTheMax(myHigh.GetRange(0, len_4));
            double M = myHigh.GetRange(0, len_4).Max();
            myHigh1 = Maxmin.FindTheMax(myHigh.GetRange((len_50), len_4));
            double W = myHigh1.Max();
            bool v = M > W;
            if (v)
            {
                return !v;
            }
            List<double> myLow1 = Maxmin.FindTheMin(myLow.GetRange((len_4 - 1), len_4));
            double L = myLow1.Min();
            myLow1 = Maxmin.FindTheMin(myLow.GetRange(len_75, 25));
            double R = myLow1.Min();
            v = ((R > M && R>L) | L!=0);
            return v;
            //you get to this point then tell the user to BUY
            //when they confirm the price they bought it save it
        }        

    }
}
