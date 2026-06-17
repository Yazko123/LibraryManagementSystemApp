using LibraryManagementSystem;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"));

services.AddScoped<BookService>();
services.AddScoped<MemberService>();
services.AddScoped<LoanService>();
services.AddScoped<ReservationService>();
services.AddScoped<FineService>();
services.AddScoped<AuthorService>();
services.AddScoped<ReportService>();

services.AddScoped<ConsoleUI>();

var provider = services.BuildServiceProvider();

var ui = provider.GetRequiredService<ConsoleUI>();

ui.Run();