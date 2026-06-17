using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class EfBookRepository
    {
        private readonly LibraryDbContext _db;

        public EfBookRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public void Add(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void Update(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
        }

        public void Delete(Book book)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public IReadOnlyList<Book> GetAll()
        {
            return _db.Books.Include(current => current.Author).ToList();
        }

        public Book GetById(int id)
        {
            Book target = _db.Books.FirstOrDefault(record => record.Id == id);

            if (target == null)
                throw new InvalidOperationException($"Requested book (ID {id}) does not exist.");

            return target;
        }
    }
}