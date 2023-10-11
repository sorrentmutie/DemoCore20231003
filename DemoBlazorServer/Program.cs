using DemoBlazorServer.Data;
using DemoBlazorServer.Services;
using DemoEFCore.Infrastructure.Movies;
using DemoMVC.Core.Interfaces;
using DemoMVC.Core.Interfaces.Movies;
using LibreriaComponentiBlazor.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IEventiPubblici, GestioneEventiFuturi>();
builder.Services.AddScoped<IWeatherForecasts, WeatherServerService>();
builder.Services.AddDbContext<MovieDbContext>(opzioni =>
   opzioni.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IGenresData, ServizioDati>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
