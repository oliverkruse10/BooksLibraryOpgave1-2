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
    public class BooksRepositoryTests
    {
        

        [TestMethod()]
        public void AddTest()
        {
          BooksRepository testrepo = new BooksRepository();
          Books book1 = new Books() { Id = 1, Title = "The Hobbit", Price = 100 };
          testrepo.Add(book1);
          Assert.AreEqual(6, testrepo.Get().Count);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BooksRepository testrepo = new BooksRepository();
            Books book1 = new Books() { Id = 1, Title = "The Hobbit", Price = 100 };
            testrepo.Add(book1);
            testrepo.Delete(1);
            Assert.AreEqual(5, testrepo.Get().Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            BooksRepository testrepo = new BooksRepository();
            Assert.AreEqual(2, testrepo.Get(minPrice: 190, maxPrice: 320, sortByPrice: true).Count);

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            BooksRepository testrepo = new BooksRepository();
            Assert.AreEqual("The Hobbit", testrepo.GetById(1).Title);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            BooksRepository testrepo = new BooksRepository();
            Books book1 = new Books() { Id = 1, Title = "The Hobbit Updated", Price = 100 };
            testrepo.Update(1, book1);
            Assert.AreEqual("The Hobbit Updated", testrepo.GetById(1).Title);
        }


    }
}