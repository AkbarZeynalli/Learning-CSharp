using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services;               
using LibraryManagementSystemm.Services.Interfaces;    
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<Data.AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Repository pattern
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // ✅ Service injection (vacib hissə)
            builder.Services.AddScoped<ILibraryService, LibraryService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();

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
