using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    internal class ILoanService
    {
        public bool CreateLoan(int bookId, int memberId)
        {
            var book = _context.Books.Find(bookId);
            var member = _context.Members.Find(memberId);

            if (book == null || member == null)
                return false;

            if (!book.IsAvailable)
                return false;

            if (member.BorrowedBooksCount >= 3)
                return false;

            Loan loan = new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                Status = LoanStatus.Active
            };

            member.BorrowedBooksCount++;
            book.IsAvailable = false;

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return true;
        }
    }
}
