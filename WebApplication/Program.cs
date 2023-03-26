using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using WebApp.BL.Interfaces;
using WebApp.BL.Services;
using WebApp.DL.Interfaces;
using WebApp.DL.Repositories;

namespace WebApplicationN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            // Add services to the container.

            builder.Services
            .AddSingleton<IAuthorRepository, AuthorRepository>();
            builder.Services
            .AddSingleton<IAuthorService, AuthorService>();
            builder.Services
            .AddSingleton<IBookRepository, BookRepository>();
            builder.Services
           .AddSingleton<IBookService, BookService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
