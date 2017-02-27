using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairGoConsole
{
    public class Cart
    {
        private bool _isSale;
        private decimal _saleDiscount = (decimal) 5.0;
        public List<BookItem> Content { get; private set; }

        public Cart()
        {
            Content = new List<BookItem>();
        }

        public bool IsSale
        {
            get { return _isSale; }
            set { _isSale = value; }
        }

        public decimal SaleDiscount
        {
            get { return _saleDiscount; }
            set { _saleDiscount = value; }
        }

        public void LoadCart()
        {
            Content = new List<BookItem>() {
                new BookItem() { Title = "Unsolved crimes",     Category = CategoryType.Crime,      Price = (decimal)10.99, Tax = (decimal)10.0 },
                new BookItem() { Title = "A Little Love Story", Category = CategoryType.Romance,    Price = (decimal)2.40,  Tax = (decimal)10.0 },
                new BookItem() { Title = "Heresy",              Category = CategoryType.Fantasy,    Price = (decimal)6.80,  Tax = (decimal)10.0 },
                new BookItem() { Title = "Jack the Ripper",     Category = CategoryType.Crime,      Price = (decimal)16.00, Tax = (decimal)10.0 },
                new BookItem() { Title = "The Tolkien Years",   Category = CategoryType.Fantasy,    Price = (decimal)22.90, Tax = (decimal)10.0 },
            };
        }

        /// <summary>
        /// Calculates the total price of the cart including sales discount if applicable
        /// </summary>
        /// <param name="isIncTax">bool to enable including tax</param>
        /// <returns>decimal value of the total calculated price</returns>
        public decimal GetTotals(bool isIncTax)
        {
            decimal total = new decimal(0.0);

            foreach (BookItem item in Content)
            {
                var price = isIncTax ? item.TotalPrice : item.Price;
                total += price;
                if (_isSale && item.Category == CategoryType.Crime) //apply discount if on sale
                {
                    total -= price * (_saleDiscount / 100);
                }
            }
            return total;
        }

    }
}
