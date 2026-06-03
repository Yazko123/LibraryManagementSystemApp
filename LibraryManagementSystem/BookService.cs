using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class BookService
{
    private readonly LibraryContext _context;

    public BookService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAll()
        => await _context.Books.Include(b => b.Author).ToListAsync();

    public async Task<Book> GetById(int id)
        => await _context.Books.FindAsync(id);

    public async Task Add(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> SearchByTitle(string title)
    {
        return await _context.Books
            .Where(b => b.Title.Contains(title))
            .ToListAsync();
    }
}