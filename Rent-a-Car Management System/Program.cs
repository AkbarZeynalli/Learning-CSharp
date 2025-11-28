
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Mapper;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System
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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<IBrandService,BrandService>();
            builder.Services.AddScoped<ICarModelService,CarModelService>();
            builder.Services.AddScoped<ICarService,CarService>();
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            builder.Services.AddScoped<IPaymentService,PaymentService>();
            builder.Services.AddScoped<IRentalService,RentalService>();

            builder.Services.AddAutoMapper(conf =>
            {
                conf.AddProfile<CarProfile>();
            });

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
