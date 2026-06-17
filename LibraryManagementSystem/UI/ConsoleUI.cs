using LibraryManagementSystem.Domain ;
using LibraryManagementSystem.Services;
using System;

namespace LibraryManagementSystem.UI
{
    public class ConsoleUI
    {
        private readonly BookService _bookService;
        private readonly MemberService _memberService;
        private readonly LoanService _loanService;
        private readonly ReservationService _reservationService;
        private readonly FineService _fineService;

        public ConsoleUI(
            BookService bookService,
            MemberService memberService,
            LoanService loanService,
            ReservationService reservationService,
            FineService fineService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _loanService = loanService;
            _reservationService = reservationService;
            _fineService = fineService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== LIBRARY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Добавяне на книга");
                Console.WriteLine("2. Редактиране на книга");
                Console.WriteLine("3. Изтриване на книга");
                Console.WriteLine("4. Търсене по заглавие");
                Console.WriteLine("5. Търсене по автор");
                Console.WriteLine("6. Търсене по жанр");
                Console.WriteLine("7. Регистрация на член");
                Console.WriteLine("8. Редактиране на член");
                Console.WriteLine("9. Създаване на заем");
                Console.WriteLine("10. Връщане на книга");
                Console.WriteLine("11. Проверка наличност");
                Console.WriteLine("12. Изчисляване на глоба");
                Console.WriteLine("13. Създаване на резервация");
                Console.WriteLine("14. Отмяна на резервация");
                Console.WriteLine("15. Просрочени заеми");
                Console.WriteLine("16. Най-четени книги");
                Console.WriteLine("17. История на член");
                Console.WriteLine("18. Активни резервации");
                Console.WriteLine("19. Отчет за заетост");
                Console.WriteLine("20. Изход");

                Console.Write("\nИзбери опция: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": UpdateBook(); break;
                    case "3": DeleteBook(); break;
                    case "4": SearchByTitle(); break;
                    case "5": SearchByAuthor(); break;
                    case "6": SearchByGenre(); break;
                    case "7": RegisterMember(); break;
                    case "8": UpdateMember(); break;
                    case "9": CreateLoan(); break;
                    case "10": ReturnBook(); break;
                    case "11": CheckAvailability(); break;
                    case "12": CalculateFine(); break;
                    case "13": CreateReservation(); break;
                    case "14": CancelReservation(); break;
                    case "15": ShowOverdueLoans(); break;
                    case "16": ShowMostBorrowed(); break;
                    case "17": MemberHistory(); break;
                    case "18": ActiveReservations(); break;
                    case "19": OccupancyReport(); break;
                    case "20": return;
                    default:
                        Console.WriteLine("Невалидна опция!");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void AddBook()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("AuthorId: ");
            int authorId = int.Parse(Console.ReadLine());

            Console.Write("Genre (Fantasy, Horror...): ");
            var genre = Console.ReadLine();

            var book = new Book
            {
                Title = title,
                AuthorId = authorId,
                Genre = Enum.Parse<Enums.Genre>(genre, true)
            };

            _bookService.AddBook(book);
            Console.WriteLine("Книгата е добавена!");
            Console.ReadKey();
        }

        private void UpdateBook()
        {
            Console.Write("Book Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New Title: ");
            string title = Console.ReadLine();

            var book = new Book { Id = id, Title = title };

            _bookService.UpdateBook(book);
            Console.WriteLine("Обновено!");
            Console.ReadKey();
        }

        private void DeleteBook()
        {
            Console.Write("Book Id: ");
            int id = int.Parse(Console.ReadLine());

            _bookService.DeleteBook(id);
            Console.WriteLine("Изтрито!");
            Console.ReadKey();
        }

        private void SearchByTitle()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();

            var result = _bookService.SearchByTitle(title);

            foreach (var b in result)
                Console.WriteLine($"{b.Id} - {b.Title}");

            Console.ReadKey();
        }

        private void SearchByAuthor()
        {
            Console.Write("Author: ");
            var author = Console.ReadLine();

            var result = _bookService.SearchByAuthor(author);

            foreach (var b in result)
                Console.WriteLine($"{b.Title}");

            Console.ReadKey();
        }

        private void SearchByGenre()
        {
            Console.Write("Genre: ");
            var genre = Console.ReadLine();

            var result = _bookService.SearchByGenre(genre);

            foreach (var b in result)
                Console.WriteLine($"{b.Title}");

            Console.ReadKey();
        }


        private void RegisterMember()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            var member = new Member { Name = name };

            _memberService.RegisterAsync(member).Wait();

            Console.WriteLine("Регистриран!");
            Console.ReadKey();
        }

        private void UpdateMember()
        {
            Console.Write("Member Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("New Name: ");
            string name = Console.ReadLine();

            var member = new Member { Id = id, Name = name };

            _memberService.UpdateAsync(member).Wait();

            Console.WriteLine("Обновен!");
            Console.ReadKey();
        }


        private void CreateLoan()
        {
            Console.Write("Book Id: ");
            int bookId = int.Parse(Console.ReadLine());

            Console.Write("Member Id: ");
            int memberId = int.Parse(Console.ReadLine());

            var result = _loanService.CreateLoan(bookId, memberId);

            Console.WriteLine(result ? "Успешен заем" : "Грешка!");
            Console.ReadKey();
        }

        private void ReturnBook()
        {
            Console.Write("Loan Id: ");
            int loanId = int.Parse(Console.ReadLine());

            var result = _loanService.ReturnBook(loanId);

            Console.WriteLine(result ? "Върната книга" : "Грешка!");
            Console.ReadKey();
        }


        private void CreateReservation()
        {
            Console.Write("Book Id: ");
            int bookId = int.Parse(Console.ReadLine());

            Console.Write("Member Id: ");
            int memberId = int.Parse(Console.ReadLine());

            _reservationService.CreateAsync(bookId, memberId).Wait();

            Console.WriteLine("Резервирано!");
            Console.ReadKey();
        }

        private void CancelReservation()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine());

            _reservationService.CancelAsync(id).Wait();

            Console.WriteLine("Отменено!");
            Console.ReadKey();
        }


        private void CalculateFine()
        {
            Console.Write("Loan Id: ");
            int id = int.Parse(Console.ReadLine());

            var fine = _fineService.CalculateFineAsync(id).Result;

            Console.WriteLine($"Глоба: {fine} лв");
            Console.ReadKey();
        }

        private void CheckAvailability() => Console.WriteLine("TODO");
        private void ShowOverdueLoans() => Console.WriteLine("TODO");
        private void ShowMostBorrowed() => Console.WriteLine("TODO");
        private void MemberHistory() => Console.WriteLine("TODO");
        private void ActiveReservations() => Console.WriteLine("TODO");
        private void OccupancyReport() => Console.WriteLine("TODO");
    }
}