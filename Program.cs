using Microsoft.EntityFrameworkCore;
using aspnetcoremvcapp.Models;
using aspnetcoremvcapp.Middleware;
using aspnetcoremvcapp.DIConfigurations;


var builder = WebApplication.CreateBuilder(args);

// Dependency Injection - Entity Framework
builder.Services.AddDatabaseContext(builder.Configuration.GetConnectionString("MvcMovieContext"));

// Configure dependencies
builder.Services.AddAppDepenencies();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add middlewares
builder.Services.AddAppMiddleware();

var app = builder.Build();

// Seed data initialization
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Use custom request logger middleware
app.UseRequestLoggerMiddleware();

app.Run();
