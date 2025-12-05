
using FMS.DAL.Data;
using FMS.DAL.Repository;
using FMS.WebAPI.Mapper;
using FMS.WebAPI.Services;
using FMS.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FMS.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(conf =>
            {
                conf.AddProfile<CustomProfile>();
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<IClubServices, ClubServices>(); 
            builder.Services.AddScoped<ICountryServices,CountryServices>();
            builder.Services.AddScoped<IGoalServices, GoalServices>();
            builder.Services.AddScoped<ILeaugeServies, LeaugeServies>();
            builder.Services.AddScoped<IMatchServices, MatchServices>();
            builder.Services.AddScoped<IPlayerServices, PlayerServices>();
            builder.Services.AddScoped<IPositionServices, PositionServices>();

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
