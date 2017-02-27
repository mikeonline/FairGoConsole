using Microsoft.VisualStudio.TestTools.UnitTesting;
using FairGoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairGoConsole.Tests
{
    [TestClass]
    public class CartTests
    {
        public Cart testCart;
        public BookItem testBookItem;
        [TestInitialize]
        public void Initialize()
        {
            testCart = new Cart();
            testCart.LoadCart();
            testBookItem = new BookItem()
            {
                Category = FairGoConsole.CategoryType.Crime,
                Price = (decimal) 1.00,
                Tax = (decimal) 10.0,
            };
        }

        [TestMethod]
        public void loadCartTest()
        {
            Assert.AreEqual(expected: 5, actual: testCart.Content.Count, message: "Cart Content does not match");
            var cartItem = testCart.Content.FirstOrDefault(x => x.Title == "Unsolved crimes");
            Assert.IsTrue(cartItem != null, "Unsolved Crimes not found");
            Assert.AreEqual(expected: (decimal)10.99, actual: cartItem.Price, message: "Unsolved Crimes price does not match");
        }

        [TestMethod]
        public void TotalCart_single_NoSale_ExTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = false;
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)1.0, actual: testCart.GetTotals(false), message: "totals dont total");
        }
        [TestMethod]
        public void TotalCart_single_NoSale_IncTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = false;
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)1.1, actual: testCart.GetTotals(true), message: "totals dont total");
        }

        [TestMethod]
        public void TotalCart_single_Sale_Crime_ExTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = true;
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)0.95, actual: testCart.GetTotals(false), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_single_Sale_Crime_IncTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = true;
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)1.045, actual: testCart.GetTotals(true), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_single_Sale_Fantasy_ExTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = true;
            testBookItem.Category = CategoryType.Fantasy; //  not on sale
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)1.0, actual: testCart.GetTotals(false), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_single_Sale_Fantasy_IncTax()
        {
            testCart = new Cart(); //reset cart
            testCart.IsSale = true;
            testBookItem.Category = CategoryType.Fantasy; //  not on sale
            testCart.Content.Add(testBookItem);
            Assert.AreEqual(expected: (decimal)1.1, actual: testCart.GetTotals(true), message: "totals dont match");
        }

        [TestMethod]
        public void TotalCart_NoSale_ExTax()
        {
            //default stock
            testCart.IsSale = false;
            Assert.AreEqual(expected: (decimal)59.09, actual: testCart.GetTotals(false), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_NoSale_IncTax()
        {
            //default stock
            testCart.IsSale = false;
            Assert.AreEqual(expected: (decimal)64.999, actual: testCart.GetTotals(true), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_Sale_ExTax()
        {
            //default stock
            testCart.IsSale = true;
            Assert.AreEqual(expected: (decimal)57.7405, actual: testCart.GetTotals(false), message: "totals dont match");
        }
        [TestMethod]
        public void TotalCart_Sale_IncTax()
        {
            //default stock
            testCart.IsSale = true;
            Assert.AreEqual(expected: (decimal)63.51455, actual: testCart.GetTotals(true), message: "totals dont match");
        }
    }
}