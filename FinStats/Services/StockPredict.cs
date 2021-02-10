using System;
using System.Linq;
using System.Collections.Generic;
namespace FinStats.Services
{
    public class StockPredict
    {
        private static List<double> BUY(int length)
        {
            char answer = 'Y';
            do
            {
                //string column = "High";
                //string column2 = "Low";
                List<double> myHigh = new List<double>();
                List<double> myLow = new List<double>();
                myHigh = Maxmin.Findthemax(length);
                double first_max = myHigh.Max();
                myLow = Maxmin.Findthemin(length);
                double first_min = myLow.Min();
                myHigh = Maxmin.Findthemax(length);
                double global_max = myHigh.Max();
                while (first_max >= global_max)
                {


                    myLow = Maxmin.Findthemin(10);
                    double local_min = myLow.Min();

                    if (local_min >= first_min)
                    {
                        Console.WriteLine("BUY NOW!!");
                        List<double> maxmin = new List<double>();
                        maxmin[0] = global_max;
                        maxmin[1] = local_min;
                        return maxmin;
                    }
                    else
                    {
                        Console.WriteLine("SO CLOSE");
                        continue;
                    }
                }
                Console.WriteLine("Try Again? [Y/N]:");
                answer = Convert.ToChar(Console.ReadLine());
            } while (answer == 'y' | answer == 'Y');
            List<double> mm = new List<double>();
            mm[0] = 0;
            mm[1] = 0;
            return mm;
        }
        private static void SELL(List<double> maxmin, int length)
        {
            double max_num = maxmin[0];
            double min_num = maxmin[1];

            List<double> myHigh = new List<double>();
            List<double> myLow = new List<double>();
            myHigh = Stock();
            myHigh = Maxmin.Findthemax(length);
            double M = myHigh.Max();
            if (max_num > M)
            {
                Console.WriteLine("THE MARKET IS SHOWING A SIGN OF WEAKNESS");
            }
            else
            {
                maxmin[0] = M;
                return;
            }
            myLow = Stock();
            myLow = Maxmin.Findthemin(length);
            double L = myLow.Min();
            if (min_num > L)
            {
                Console.WriteLine("ALMOST TIME TO SELL");
            }
            else
            {
                maxmin[1] = L;
                return;
            }
            myHigh = Maxmin.Findthemax(length);
            double W = myHigh.Max();
            if (W < M)
            {
                Console.WriteLine("SELL ALREADY!");
                return;
            }
            else
            {
                Console.WriteLine("Looks like the market is good...for now.");
                return;
            }



            //when to sell function(price they bought it. call it price and ask for the risk)    
            /*PROGRAM 1
            *while price < 0.75 *risk of money they are willing to lose 
            *THIS WHILE LOOP NEEDS TO BE CONSTANTING HAPPENING and collecting each high or low price
            *like a separate program
            *or dont care because most financial companies ALREADY have this
            */

            /*PROGRAM 2
            *find the max function H
            *find the min function call it Q
            *if Q is lower than the price you paid
            *write a sign of weakness
            *else restart program 2
            *find the max function T
            *if T is lower than the H
            *write  get ready to sell
            *else restart program 2
            *find the the min call it OHNO 
            *if OHNO is lower than Q
            *SELL NOW
            *else restart program 2
            */

        }
        private static List<double> Stock(AppDb db)
        {
            throw new NotImplementedException();
        }
    }
}
