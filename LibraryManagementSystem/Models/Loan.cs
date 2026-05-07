using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public Book Book { get; set; }
        public Member Member { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }

        // Създаване на заем
        public void CreateLoan()
        {
            if (Book.IsAvailable && Member.CanBorrowBook())
            {
                Book.IsAvailable = false;

                Member.BorrowedBooksCount++;

                LoanDate = DateTime.Now;
                DueDate = LoanDate.AddDays(14);

                Console.WriteLine("Loan created successfully.");
            }
            else
            {
                Console.WriteLine("Loan cannot be created.");
            }
        }

        // Връщане на книга
        public void ReturnBook()
        {
            if (!IsReturned)
            {
                IsReturned = true;

                Book.IsAvailable = true;

                Member.BorrowedBooksCount--;

                Console.WriteLine("Book returned successfully.");
            }
        }

        // Проверка за просрочие
        public bool IsOverdue()
        {
            return DateTime.Now > DueDate && !IsReturned;
        }

        // Изчисляване на глоба
        public double CalculateFine()
        {
            if (IsOverdue())
            {
                int overdueDays = (DateTime.Now - DueDate).Days;
                return overdueDays * 0.50;
            }

            return 0;
        }
    }
}
