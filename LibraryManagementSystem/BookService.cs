using LibraryManagementSystem.Data;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly LibraryDb _context;

    public BookService(LibraryDb context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAll()
        => await _context.Books.Include(b => b.Author).ToListAsync();

    public async Task<Book> GetById(int id)
        => await _context.Books.Include(b => b.Author)
                               .FirstOrDefaultAsync(b => b.Id == id);

    public async void AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async void UpdateBook(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async void DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        return _context.Books
            .Where(b => b.Title.Contains(title));
    }

    public IEnumerable<Book> SearchByAuthor(string author)
    {
        return _context.Books
            .Include(b => b.Author)
            .Where(b => (b.Author.FirstName + " " + b.Author.LastName)
            .Contains(author));
    }

    public IEnumerable<Book> SearchByGenre(string genre)
    {
        if (Enum.TryParse<Genre>(genre, true, out var parsed))
        {
            return _context.Books.Where(b => b.Genre == parsed);
        }

        return Enumerable.Empty<Book>();
    }

    public bool CheckAvailability(int bookId)
    {
        var book = _context.Books.Find(bookId);
        return book?.IsAvailable ?? false;
    }
}