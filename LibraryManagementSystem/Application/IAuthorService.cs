using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;

namespace LibraryManagementSystem.Application
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(int id);

        Task<List<Author>> SearchByNameAsync(string name);

        Task AddAsync(Author author);

        Task UpdateAsync(Author author);

        Task DeleteAsync(int id);
    }
}