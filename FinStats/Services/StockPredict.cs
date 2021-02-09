namespace FinStats.Services
{
    public class StockPredict
    {
        private static List<double> BUY(int length)
        {
            string column = "High";
            string column2 = "Low";
            List<double> myHigh = new List<double>();
            List<double> myLow = new List<double>();
            myHigh = Findthemax(column, myHigh, length);
            double first_max = myHigh.Max();
            myLow = Collectdata(column2, length);
            myLow = Findthemin(column2, myLow, length);
            double first_min = myLow.Min();
            myHigh = Findthemax(column, myHigh, length);
            double global_max = myHigh.Max();
            while (first_max >= global_max)
            {


                myLow = Findthemin(column2, myLow, length);
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
                }
            }
        private static void SELL(List<double> maxmin, int length)
        {
            string column = "High";
            string column2 = "Low";
            double max_num = maxmin[0];
            double min_num = maxmin[1];

            List<double> myHigh = new List<double>();
            List<double> myLow = new List<double>();
            myHigh = Findthemax(column, myHigh, length);
            double M = myHigh.Max();
            if (max_num > M)
            {
                Console.WriteLine("THE MARKET IS SHOWING A SIGN OF WEAKNESS");
            }
            else
            {
                maxmin[0] = M;
                /*start a separate solution called finstats.console
                 * make it exactly but separate the logic 
                 * move it 
                 * console app will do will have that loop logic and if it doesnt meet that
                 * will go server and call it
                 * have the server to do the brainy stuff
                 * you do that verification
                 * do while a loop to check if true
                 * 
                 * MAKE IT A WHILE LOOP NOT RECURSIVE
                 */
                return;
            }
            myLow = Collectdata("Low" length);
            myLow = Findthemin("Low", myLow, length);
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
            myHigh = Findthemax("High", myHigh, length);
            double W = myHigh.Max();
            if (W < M)
            {
                Console.WriteLine("SELL ALREADY!");
                return;
                //use return void
            }
            else
            {
                Console.WriteLine("Looks like the market is good...for now.");
                //void return
                return;
                ;
            }

        }

                //you get to this point then tell the user to BUY
                //when they confirm the price they bought it save it
            }
     
     
    }
}
