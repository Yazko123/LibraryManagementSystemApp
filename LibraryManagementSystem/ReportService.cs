using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Services
{
    public class ReportService : IReportService
    {
        private readonly LibraryDb _context;

        public ReportService(LibraryDb context)
        {
            _context = context;
        }

        public async Task<int> GetMostBorrowedBooksCountAsync()
        {
            return await _context.Loans
                .GroupBy(l => l.BookId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetMostBorrowedBooksAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .GroupBy(l => l.Book.Title)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToListAsync();
        }

        public async Task<int> GetTotalActiveLoansAsync()
        {
            return await _context.Loans.CountAsync(l => !l.IsReturned);
        }

        public async Task<int> GetOverdueLoansCountAsync()
        {
            return await _context.Loans
                .CountAsync(l => !l.IsReturned && l.DueDate < DateTime.Now);
        }

        public async Task<Dictionary<string, int>> GetLoansByGenreReportAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .GroupBy(l => l.Book.Genre.ToString())
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }
    }
}