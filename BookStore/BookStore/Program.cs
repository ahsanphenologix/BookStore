using BookStore.AppDataConnections;
using BookStore.Interfaces;
using BookStore.Mappers;
using BookStore.Repositories;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;

// Configure database connection using Entity Framework Core

builder.Services.AddScoped<IBookRepository, BookStoreRepository>();
builder.Services.AddScoped<IDapperDbConnection, DapperDbConnection>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
