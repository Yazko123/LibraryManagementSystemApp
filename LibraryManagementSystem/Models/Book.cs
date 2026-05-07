using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        public void BorrowBook()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Book is not available.");
            }
        }

        public void ReturnBook()
        {
            IsAvailable = true;
            Console.WriteLine("Book returned.");
        }
    }
}
