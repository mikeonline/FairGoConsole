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
                    localCart.IsSale = true;
                }
            }
            localCart.LoadCart();
            var totals = localCart.GetTotals();
            
            System.Console.Write("Total for order ");
            if (localCart.IsSale)
            {
                System.Console.Write("with salers discount");
            }
            System.Console.Write("is {0:c2}",localCart.GetTotals());
        }

    }
}
