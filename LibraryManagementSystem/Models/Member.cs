namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BorrowedBooksCount { get; set; }

        public bool CanBorrowBook() => BorrowedBooksCount < 3;
    }
}