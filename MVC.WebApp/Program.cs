using Example.EF.DbContexts;
using Microsoft.EntityFrameworkCore;
using MVC.WebApp.DependencyInjection;

namespace MVC.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddDbContext<ExampleDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"));
            });
            builder.Services.GetServices();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();

            app.Run();
        }
    }
}
