﻿using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Step01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 7
            //builder.Services.AddDbContext<AppDbContext>();
            // 10
            // appsettings.json dosyası içinde bulunan Connection Stringi öğreniyor.
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer           (builder.Configuration.GetConnectionString("Conn")));

            // Service Configuration
            builder.Services.AddScoped<IActorsService, ActorsService>(); // 22.
            builder.Services.AddScoped<IProducersService, ProducersService>(); // 36.1
            builder.Services.AddScoped<ICinemasService, CinemasService>(); // 37.1      
            builder.Services.AddScoped<IMoviesService, MoviesService>(); //38.1



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

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //19
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");

            // 15
            AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}
