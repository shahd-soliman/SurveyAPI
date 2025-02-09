
using Survey.app.Middlewares;
using Survey.app.Services;
using Mapster;
using System.Reflection;
using Survey.app.IndependencyInjection;
namespace Survey.app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependencies(builder.Configuration).AddDataBase(builder.Configuration);
            //builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseLoggerMiddleWare();
            app.UseHttpsRedirection();

            app.UseAuthorization();

           // app.MapIdentityApi<ApplicationUser>();
            app.MapControllers();
            app.UseExceptionHandler();
            app.Run();
        }
    }
}
