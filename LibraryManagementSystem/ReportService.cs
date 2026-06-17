using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class ReportService
    {
        private readonly LibraryDbContext _context;

        public ReportService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetOverdueLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .Where(l => !l.IsReturned && l.DueDate < DateTime.Now)
                .ToListAsync();
        }

       
        public async Task<List<string>> GetMostBorrowedBooksAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .GroupBy(l => l.Book.Title)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key} - {g.Count()} заема")
                .ToListAsync();
        }


       
        public async Task<List<Loan>> GetMemberLoanHistoryAsync(int memberId)
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Where(l => l.MemberId == memberId)
                .OrderByDescending(l => l.LoanDate)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetActiveReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Book)
                .Include(r => r.Member)
                .Where(r => r.IsActive && r.ExpirationDate > DateTime.Now)
                .ToListAsync();
        }

    
        public async Task<double> GetLibraryOccupancyRateAsync()
        {
            var totalBooks = await _context.Books.CountAsync();
            var borrowedBooks = await _context.Loans
                .CountAsync(l => !l.IsReturned);

            if (totalBooks == 0)
                return 0;

            return (double)borrowedBooks / totalBooks * 100;
        }

        public async Task<int> GetActiveLoansCountAsync()
        {
            return await _context.Loans
                .CountAsync(l => !l.IsReturned);
        }

      
        public async Task<Dictionary<string, int>> GetLoansByGenreAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .GroupBy(l => l.Book.Genre.ToString())
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }
    }
}