using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public string Name { get; set; }
        public int BorrowedBooksCount { get; set; }

        public bool CanBorrowBook()
        {
            return BorrowedBooksCount < 3;
        }

        public void BorrowBook()
        {
            if (CanBorrowBook())
            {
                BorrowedBooksCount++;
                Console.WriteLine("Book borrowed.");
            }
            else
            {
                Console.WriteLine("Maximum limit reached.");
            }
        }

        public void ReturnBook()
        {
            if (BorrowedBooksCount > 0)
            {
                BorrowedBooksCount--;
                Console.WriteLine("Book returned.");
            }
        }
    }
}
