using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);

        Task<Reservation> CreateAsync(int bookId, int memberId);
        Task CancelAsync(int reservationId);

        Task<List<Reservation>> GetActiveReservationsAsync(int memberId);
        Task<bool> CanBorrowReservedBookAsync(int bookId, int memberId);
    }
}