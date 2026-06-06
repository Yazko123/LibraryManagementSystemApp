using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class LoanService
    {
        private readonly LibraryDb _context;

        public LoanService(LibraryDb context)
        {
            _context = context;
        }

        public bool CreateLoan(int bookId, int memberId)
        {
            var book = _context.Books
                .Include(b => b.Loans)
                .FirstOrDefault(b => b.Id == bookId);

            var member = _context.Members
                .Include(m => m.Loans)
                .FirstOrDefault(m => m.Id == memberId);

            if (book == null || member == null)
                return false;

            if (!member.CanBorrowBook())
                return false;

            if (!book.IsAvailable)
                return false;

            var loan = new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                IsReturned = false
            };

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return true;
        }

        // ✔️ НОВО: връщане на книга
        public bool ReturnBook(int loanId)
        {
            var loan = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefault(l => l.Id == loanId);

            if (loan == null || loan.IsReturned)
                return false;

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.Now;

            _context.SaveChanges();
            return true;
        }
    }
}