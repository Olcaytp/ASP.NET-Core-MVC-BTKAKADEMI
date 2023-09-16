using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("StoreApp")
    ));

    //provides cache memory and session management
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddSession();
    // builder.Services.AddHttpContextAccessor(); //ioc dahilinde kullanilmasi daha dogru olur
    //httpContext ifadesine ersimek icin bir accessor'a ihtiyac var. bu da ioc ile saglanir.
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//IoC için interface ve concrete tanımlamaları yapılmalı.
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

// builder.Services.AddSingleton<Cart>();  // One object for all requests, service registered as singleton
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));  // One object for each request, service registered as scoped
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession(); //session middleware, to use session

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    // endpoints.MapControllers();
});

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/btk", () => "BTK Akademi");
*/

app.Run();