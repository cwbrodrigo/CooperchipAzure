using Cooperchip.Demo.Data.Data.ORM;
using Cooperchip.ItDeveloper.Mvc.Extensions.Repository;
using Microsoft.EntityFrameworkCore;
using static Cooperchip.ItDeveloper.Mvc.Extensions.Utils.Utilities;

namespace Cooperchip.ItDeveloper.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddSingleton<IUtilities, Mappers>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //builder.Services.AddControllersWithViews()
            //.AddRazorOptions(options =>
            //{
            //    options.ViewLocationFormats.Add("/{0}.cshtml");
            //});

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}