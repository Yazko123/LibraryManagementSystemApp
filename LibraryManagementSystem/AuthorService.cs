
using LibraryManagementSystem.Application;
using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Author>> GetAllAsync()
            => await _context.Authors.Include(a => a.Books).ToListAsync();

        public async Task<Author> GetByIdAsync(int id)
            => await _context.Authors.Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<Author>> SearchByNameAsync(string name)
        {
            return await _context.Authors
                .Where(a => a.FirstName.Contains(name) ||
                            a.LastName.Contains(name))
                .ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
