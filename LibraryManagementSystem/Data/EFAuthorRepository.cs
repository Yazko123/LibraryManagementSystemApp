using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class EfAuthorRepository : IAuthorService
    {
        private readonly LibraryDbContext _db;

        public EfAuthorRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Author> GetAll()
        {
            List<Author> items = _db.Authors.ToList();
            return items;
        }

        public Author GetById(int id)
        {
            Author entity = _db.Authors.SingleOrDefault(item => item.Id == id);

            if (entity is null)
                throw new InvalidOperationException($"Could not find an author with ID: {id}");

            return entity;
        }

        public void Add(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void Update(Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
        }

        public void Delete(Author author)
        {
            _db.Authors.Remove(author);
            _db.SaveChanges();
        }
    }
}