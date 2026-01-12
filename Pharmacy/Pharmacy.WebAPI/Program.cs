using Microsoft.EntityFrameworkCore;
using Pharmacy.BLL.Mapper;
using Pharmacy.BLL.Services;
using Pharmacy.BLL.Services.Interfaces;
using Pharmacy.DAL.Data;
using Pharmacy.DAL.Repository;
using Serilog;

namespace Pharmacy.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1️⃣ Serilog konfiqurasiya
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // minimum log səviyyəsi
                .Enrich.FromLogContext() // loglara kontekst əlavə edir
                .WriteTo.Console()       // konsola yaz
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // fayla yaz
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // 2️⃣ Builder-in default loggerini Serilog ilə əvəz et
            builder.Host.UseSerilog();

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(conf =>
            {
                conf.AddProfile<CustomProfile>();
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDrugservice, DrugService>();

            var app = builder.Build();

            // Global exception handling üçün Serilog middleware əlavə etmək olar
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unhandled exception while processing request");
                    throw;
                }
            });

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
