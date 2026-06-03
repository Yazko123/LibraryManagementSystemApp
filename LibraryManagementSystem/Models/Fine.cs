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
    }
}