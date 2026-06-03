using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly LibraryDb _context;

        public ReservationService(LibraryDb context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateAsync(int bookId, int memberId)
        {
            var reservation = new Reservation
            {
                BookId = bookId,
                MemberId = memberId,
                ReservationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(7),
                IsActive = true
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task CancelAsync(int reservationId)
        {
            var res = await _context.Reservations.FindAsync(reservationId);
            if (res != null)
            {
                res.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Reservation>> GetAllAsync()
            => await _context.Reservations.ToListAsync();

        public async Task<Reservation> GetByIdAsync(int id)
            => await _context.Reservations.FindAsync(id);

        public async Task<List<Reservation>> GetActiveReservationsAsync(int memberId)
        {
            return await _context.Reservations
                .Where(r => r.MemberId == memberId && r.IsActive)
                .ToListAsync();
        }

        public async Task<bool> CanBorrowReservedBookAsync(int bookId, int memberId)
        {
            return await _context.Reservations
                .AnyAsync(r => r.BookId == bookId &&
                               r.MemberId == memberId &&
                               r.IsActive);
        }
    }
}