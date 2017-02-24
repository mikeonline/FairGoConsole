using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairGoConsole
{
    public enum CategoryType { Crime, Romance, Fantasy, }

    public class BookItem
    {
        public string Title { get; set; }
        public CategoryType Category { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }

        public decimal TotalPrice => Price + (Price*(Tax/100));
    }
}
