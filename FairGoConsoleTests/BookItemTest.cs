using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairGoConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairGoConsoleTests
{
    [TestClass]
    public class BookItemTest
    {
        [TestMethod]
        public void TotalPriceTest()
        {
            //setup
            var TestItem = new BookItem() { Title = "Title", Category = CategoryType.Crime, Price = (decimal)1.00,Tax = (decimal)10.0};
            //Assert
            Assert.AreEqual(expected: (decimal)1.10, actual: TestItem.TotalPrice, message: "BookItem Totals dont match expected");
        }
    }
}
