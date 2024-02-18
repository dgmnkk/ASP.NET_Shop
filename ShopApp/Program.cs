using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using ShopApp.Services;
using Microsoft.AspNetCore.Identity;
using ShopApp.Data;
using ShopApp.Data.Entities;
using ShopApp.Helpers;

public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var connStr = builder.Configuration.GetConnectionString("LocalDb");
		// Add services to the container.
		builder.Services.AddControllersWithViews();
		builder.Services.AddDbContext(connStr);

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ShopDbContext>();

        builder.Services.AddAutoMapper();
		builder.Services.AddFluentValidators();

		builder.Services.AddCustomServices();
        builder.Services.AddScoped<ICartService, CartService>();

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromDays(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            Seeder.SeedRoles(scope.ServiceProvider).Wait();
            Seeder.SeedAdmin(scope.ServiceProvider).Wait();
        }
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
        app.UseSession();

        app.MapRazorPages();
        app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}
