using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public class BooksRepository
    {
        private int nextId = 1;
        private List<Books> booksLib = new List<Books>();

        public BooksRepository()
        {
            booksLib.Add(new Books { Id = nextId++, Title = "The Hobbit", Price = 100 });
            booksLib.Add(new Books { Id = nextId++, Title = "The Lord of the Rings", Price = 200 });
            booksLib.Add(new Books { Id = nextId++, Title = "The Silmarillion", Price = 300 });
            booksLib.Add(new Books { Id = nextId++, Title = "The Children of Hurin", Price = 400 });
            booksLib.Add(new Books { Id = nextId++, Title = "Unfinished Tales", Price = 500 });
        }

        public Books Add(Books book)
        {   
            book.Validate();
            book.Id = nextId++;
            booksLib.Add(book);
            return book;
        }

        public List<Books> Get(int? minPrice = null, int? maxPrice = null, bool sortByTitle = false, bool sortByPrice = false)
        {
            
            List<Books> result = new List<Books>(booksLib);

            
            if (minPrice.HasValue || maxPrice.HasValue)
            {
                result = result.Where(book =>
                    (!minPrice.HasValue || book.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || book.Price <= maxPrice.Value))
                    .ToList();
            }

            
            if (sortByTitle)
            {
                result = result.OrderBy(book => book.Title).ToList();
            }
            else if (sortByPrice)
            {
                result = result.OrderBy(book => book.Price).ToList();
            }

            return result;
        }

        public Books GetById(int id)
        {
            return booksLib.FirstOrDefault(book => book.Id == id);
        }

        public Books Update(int id, Books book)
        {
            book.Validate();
            Books bookToUpdate = booksLib.FirstOrDefault(b => b.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
            }
            
            return bookToUpdate;
        }

        public Books Delete(int id)
        {
            Books bookToDelete = booksLib.FirstOrDefault(b => b.Id == id);
            
            if (bookToDelete != null)
            {
                booksLib.Remove(bookToDelete);
            }

            return bookToDelete;
        }


    }
}
