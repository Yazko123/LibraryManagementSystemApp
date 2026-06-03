using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class LoanService
{
    private readonly LibraryContext _context;

    public LoanService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<string> CreateLoan(int bookId, int memberId)
    {
        var book = await _context.Books.FindAsync(bookId);

        if (book == null)
            return "Book not found";

        if (!book.IsAvailable)
            return "Book is not available";

        var loan = new Loan
        {
            BookId = bookId,
            MemberId = memberId,
            LoanDate = DateTime.Now,
            IsReturned = false
        };

        book.IsAvailable = false;

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return "Loan created";
    }

    public async Task<decimal> ReturnBook(int loanId)
    {
        var loan = await _context.Loans
            .Include(l => l.Book)
            .FirstOrDefaultAsync(l => l.Id == loanId);

        if (loan == null || loan.IsReturned)
            return 0;

        loan.IsReturned = true;
        loan.ReturnDate = DateTime.Now;

        loan.Book.IsAvailable = true;

        int allowedDays = 14;
        int lateDays = (loan.ReturnDate.Value - loan.LoanDate).Days - allowedDays;

        decimal fine = lateDays > 0 ? lateDays * 1m : 0;

        await _context.SaveChangesAsync();

        return fine;
    }

    public async Task<List<Loan>> GetOverdueLoans()
    {
        int allowedDays = 14;

        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.Member)
            .Where(l => !l.IsReturned &&
                        EF.Functions.DateDiffDay(l.LoanDate, DateTime.Now) > allowedDays)
            .ToListAsync();
    }
}