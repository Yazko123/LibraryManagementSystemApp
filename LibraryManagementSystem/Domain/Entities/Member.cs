using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Loan> Loans { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

        public int ActiveLoansCount =>
            Loans?.Count(l => !l.IsReturned) ?? 0;

        public bool CanBorrowBook()
        {
            return ActiveLoansCount < 3;
        }
    }
}