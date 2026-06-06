using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public async Task<decimal> CalculateFineAsync(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);

            if (loan == null)
                return 0;

            if (loan.IsReturned)
                return 0;

            if (DateTime.Now <= loan.DueDate)
                return 0;

            var days = (DateTime.Now - loan.DueDate).Days;

            return days * 1.00m; // ✔ по-реалистично (1 лв/ден)
        }
    }



}