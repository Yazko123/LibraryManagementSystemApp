using LibraryManagementSystem;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class EfLoanRepository 
    {
        private readonly LibraryDbContext _db;

        public EfLoanRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Loan> GetAll()
        {
            throw new NotImplementedException("The GetAll method for loans is not yet implemented.");
        }

        public IReadOnlyList<Loan> GetByBook(int bookId)
        {
            throw new NotImplementedException("The GetByBook method for loans is not yet implemented.");
        }

        public IReadOnlyList<Loan> GetByMember(int memberId)
        {
            throw new NotImplementedException("The GetByMember method for loans is not yet implemented.");
        }

        public void Save(Loan loan)
        {
            throw new NotImplementedException("The Save method for loans is not yet implemented.");
        }

        public void Update(Loan loan)
        {
            throw new NotImplementedException("The Update method for loans is not yet implemented.");
        }
    }
}