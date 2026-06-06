using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly LibraryDb _context;

        public LoanService(LibraryDb context)
        {
            _context = context;
        }

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

            var loan = new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                IsReturned = false
            };

            book.IsAvailable = false;
            member.BorrowedBooksCount++;

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return true;
        }
    }
}