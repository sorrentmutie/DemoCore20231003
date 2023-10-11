

using DemoAPIMinimal;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var url = "/genres";
var genreGroup = app.MapGroup(url).WithOpenApi(); 




// genreGroup.MapGet("/", async ( MovieDbContext context ) => await context.Genres.ToListAsync());
genreGroup.MapGet("/", GenresHelpers.GetAllGenres);
genreGroup.MapGet("/{id}", GenresHelpers.GetGenreById);
genreGroup.MapPost("/", GenresHelpers.CreateGenre);
genreGroup.MapPut("/{id:int}", GenresHelpers.UpdateGenre);
genreGroup.MapDelete("/{id:int}", GenresHelpers.DeleteGenre);



app.UseCors(MyAllowSpecificOrigins);

app.Run();