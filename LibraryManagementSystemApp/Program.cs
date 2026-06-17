using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagementSystem.UI;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<LibraryDb>(options =>
            options.UseSqlServer(
                context.Configuration.GetConnectionString("LibraryDb")));

        // services
        services.AddScoped<BookService>();
        services.AddScoped<MemberService>();
        services.AddScoped<LoanService>();
        services.AddScoped<ReservationService>();
        services.AddScoped<FineService>();

        services.AddScoped<ConsoleUI>();
    })
    .Build();

var ui = builder.Services.GetRequiredService<ConsoleUI>();
ui.Run();