using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairGoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart localCart = new Cart();
            if (args.Length <= 0)
            {
                localCart.IsSale = false;
            }
            else
            {
                if (args[0] == "-sale")
                {
                    System.Console.WriteLine("ITS ON SALE!");
                    System.Console.WriteLine("(Prices include {0}% sales discount on crime titles)",localCart.SaleDiscount);
                    localCart.IsSale = true;
                }
            }
            localCart.LoadCart();

            System.Console.WriteLine("Total Cost is {0:c2}", localCart.GetTotals(false));
            System.Console.WriteLine("Total Cost Inc. Tax is {0:c2}", localCart.GetTotals(true));
        }

    }
}
