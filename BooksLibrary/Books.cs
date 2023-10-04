using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksLibrary
{
    public class Books
    {

        public Books()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters");
            }
        }

        public void ValidatePrice()
        {
            if (Price == null)
            {
                throw new ArgumentNullException("Price cannot be null");
            }
            if (Price <= 0 || Price > 1200)
            {
                throw new ArgumentException("Price must be between 0 and 1200.");
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }




        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }


    }
}
