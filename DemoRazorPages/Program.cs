using DemoEFCore.Infrastructure;
using DemoEFCore.Infrastructure.Movies;
using DemoMVC.Core.Interfaces;
using DemoMVC.Core.Interfaces.Northwind;
using DemoRazorPages.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>(
    opzioni => opzioni.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<MovieDbContext>(
       opzioni => opzioni.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));
builder.Services.AddScoped<DbContext, MovieDbContext>();    

builder.Services.AddScoped<ICategoriesData, CategoriesService>();
builder.Services.AddScoped<IRepository<Genre, int>, EFRepository<Genre, int>>();
builder.Services.AddScoped<IGenreDataService, GenreDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
