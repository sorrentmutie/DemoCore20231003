

using DemoEFCore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(
    opzioni => opzioni.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped<IService, ServiceOne>();
//builder.Services.Add(descriptor);
//builder.Services.AddScoped<IService, ServiceTwo>();

//builder.Services.TryAddScoped<IService, ServiceOne>();
//builder.Services.TryAddScoped<IService, ServiceOne>();
//builder.Services.TryAddSingleton<IService, ServiceTwo>();


//builder.Services.AddScoped<IService, ServiceOne>();
//builder.Services.AddSingleton<IService, ServiceOne>();
//builder.Services.AddScoped<IService, ServiceTwo>();

var descriptor = new ServiceDescriptor(typeof(IService), typeof(ServiceOne), ServiceLifetime.Scoped);
var descriptor2 = new ServiceDescriptor(typeof(IService), typeof(ServiceTwo), ServiceLifetime.Scoped);

builder.Services.TryAddEnumerable(new[] { descriptor, descriptor2, descriptor});

builder.Services.ConfigureOptions<SetUpJwtOptions>();

builder.Services.Configure<Features>(
    Features.Personalize,
    builder.Configuration.GetSection("Features:Personalize"));

builder.Services.Configure<Features>(
    Features.Recommender,
    builder.Configuration.GetSection("Features:Recommender"));

builder.Services.AddOptions<MyCustomSettings>()
    .Bind(builder.Configuration.GetSection("MyCustomSettings"))
    .ValidateDataAnnotations();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
