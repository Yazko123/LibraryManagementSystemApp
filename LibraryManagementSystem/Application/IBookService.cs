using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application
{
    public interface IBookService
    {
        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int id);

        IEnumerable<Book> SearchByTitle(string title);

        IEnumerable<Book> SearchByAuthor(string author);

        IEnumerable<Book> SearchByGenre(string genre);

        bool CheckAvailability(int bookId);
    }
}