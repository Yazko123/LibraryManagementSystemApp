using LibraryManagementSystem.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<Loan> Loans { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();

        public bool IsAvailable =>
            !Loans.Any(l => !l.IsReturned);
    }
}