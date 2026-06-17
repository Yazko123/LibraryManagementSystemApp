using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class FineService
    {
        private readonly LibraryDbContext _context;

        public FineService(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<decimal> CalculateFineAsync(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);

            if (loan == null || loan.IsReturned)
                return 0;

            if (DateTime.Now <= loan.DueDate)
                return 0;

            var days = (DateTime.Now - loan.DueDate).Days;
            return days * 0.50m;
        }

        public async Task<Fine> CreateFineAsync(int loanId, int memberId)
        {
            var amount = await CalculateFineAsync(loanId);

            var fine = new Fine
            {
                LoanId = loanId,
                MemberId = memberId,
                Amount = amount,
                IsPaid = false,
                CreatedDate = DateTime.Now
            };

            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();

            return fine;
        }

        public async Task PayFineAsync(int fineId)
        {
            var fine = await _context.Fines.FindAsync(fineId);

            if (fine != null)
            {
                fine.IsPaid = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Fine>> GetUnpaidFinesAsync()
        {
            return await _context.Fines
                .Where(f => !f.IsPaid)
                .ToListAsync();
        }
    }
}
