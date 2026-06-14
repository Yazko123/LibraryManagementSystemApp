namespace LibraryManagementSystem.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }


        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(7);

        public bool IsActive { get; set; } = true;
        public bool IsExpired =>
    !IsActive && DateTime.Now > ExpirationDate;
    }
}