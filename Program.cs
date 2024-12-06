using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRQCS.Classes;

namespace BRQCS
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;

            List<string> response = new List<string>();
            DateTime reference;
            int n;

            string refDate = Console.ReadLine();
            if (!DateTime.TryParse(refDate, out reference))
            {
                Console.WriteLine("ERROR");
                Console.ReadKey();
                return;
            }

            string numberTrades = Console.ReadLine();
            if (!int.TryParse(numberTrades, out n))
            {
                Console.WriteLine("ERROR");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                string[] tradeInfo = Console.ReadLine().Split(' ');

                try
                {
                    Trade trade = new Trade(Convert.ToDouble(tradeInfo[0]), tradeInfo[1], Convert.ToDateTime(tradeInfo[2]));
                    response.Add(trade.Calculate(reference));
                }
                catch(Exception ex)
                {
                    response.Add("ERROR");
                }
            }

            Console.WriteLine();
            for (int i = 0; i < response.Count; i++)
            {
                Console.WriteLine(response[i]);
            }

            Console.ReadKey();
        }
    }
}
