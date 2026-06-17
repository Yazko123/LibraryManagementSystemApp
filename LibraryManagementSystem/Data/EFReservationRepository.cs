 using LibraryManagementSystem;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class EfReservationRepository 
    {
        private readonly LibraryDbContext _db;

        public EfReservationRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public void Save(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Reservation> GetByMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Reservation> GetByBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}