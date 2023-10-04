using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Tests
{
    [TestClass()]
    public class BooksTests
    {
        

        [TestMethod()]
        public void ValidateTitleTest()
        {
            Books book1 = new Books() { Id = 1, Title = "The Hobbit", Price = 100 };
            book1.ValidateTitle();

            Books book2 = new Books() { Id = 2, Title = null, Price = 200 };
            Assert.ThrowsException<ArgumentNullException>(
                () => book2.ValidateTitle());

            Books book3 = new Books() { Id = 3, Title = "ab", Price = 300 };
            Assert.ThrowsException<ArgumentException>(
                               () => book3.ValidateTitle());

            Books book4 = new Books() { Id = 4, Title = "abc", Price = 300 };
            book1.ValidateTitle();

        }

        [TestMethod()]
        public void ValidatePriceTest()
        {

            Books book1 = new Books() { Id = 1, Title = "The Hobbit", Price = 100 };
            book1.ValidatePrice();

            Books book2 = new Books() { Id = 2, Title = "The Hobbit", Price = 0 };
            Assert.ThrowsException<ArgumentException>(
                               () => book2.ValidatePrice());

            Books book3 = new Books() { Id = 3, Title = "The Hobbit", Price = 1201 };
            Assert.ThrowsException<ArgumentException>(
                               () => book3.ValidatePrice());

            Books book4 = new Books() { Id = 4, Title = "The Hobbit", Price = null };
            Assert.ThrowsException<ArgumentNullException>(
                                              () => book4.ValidatePrice());

            
        }




    }
}