

using DemoAPIMinimal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var url = "/genres";
var genreGroup = app.MapGroup(url);




// genreGroup.MapGet("/", async ( MovieDbContext context ) => await context.Genres.ToListAsync());
genreGroup.MapGet("/", GenresHelpers.GetAllGenres);
genreGroup.MapGet("/{id}", GenresHelpers.GetGenreById);
genreGroup.MapPost("/", GenresHelpers.CreateGenre);
genreGroup.MapPut("/{id:int}", GenresHelpers.UpdateGenre);
genreGroup.MapDelete("/genres/{id:int}", GenresHelpers.DeleteGenre);


//app.MapPatch("/movies/{id:int}", async (int id, Movie movie, MovieDbContext context) =>
//{
//    //var movieDb = await context.Movies.FindAsync(id);
//    //if(movieDb == null) return Results.NotFound();
//    //context.Entry(movieDb).State = EntityState.Detached;
//    //context.Entry(movie).State = EntityState.Modified;
//    context.Movies.Update(movie);
//    await context.SaveChangesAsync();
//    return Results.NoContent();    
//});


app.Run();