using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    internal class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Biography { get; set; }

        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int GetBooksCount()
        {
            return Books.Count;
        }

        public void AddBook(Book book)
        {
            if (book != null && !Books.Contains(book))
            {
                Books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (book != null)
            {
                Books.Remove(book);
            }
        }
    }
}

