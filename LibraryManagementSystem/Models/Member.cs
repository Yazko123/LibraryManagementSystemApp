using System.Collections.Generic;
namespace LibraryManagementSystem.Models

{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BorrowedBooksCount { get; set; }

        public List<Loan> Loans { get; set; } = new();                                                                                                                                                                                                                                                                                                                                                                                                                    
        public List<Reservation> Reservations { get; set; } = new();

        public bool CanBorrowBook() => BorrowedBooksCount < 3;
    }
}