using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;

namespace LibraryManagementSystem.Application
{
    public interface IAuthorRepository
    {
        IReadOnlyList<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}