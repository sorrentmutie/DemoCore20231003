using DemoMVC.Core.DTO;

namespace DemoAPIMinimal;

public static class GenresExtensions
{
    public static GenreDTO  ToDTO(this Genre genre)
    {
        return new GenreDTO
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }  
    
    public static Genre FromDTO(this GenreDTO genre)
    {
        return new Genre
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }

    public static List<GenreDTO> genreDTOs(this List<Genre> genres)
    {
        return genres.Select(g => g.ToDTO()).ToList();
    }
}

public static class GenresHelpers
{
    public static async Task<IResult> GetAllGenres(MovieDbContext context)
    {
        //Thread.Sleep(3000);

        var genres = await context.Genres.ToListAsync();

        return TypedResults.Ok(genres.genreDTOs());
    }

    public static async Task<IResult> GetGenreById(int id, MovieDbContext context)
    {
        return await context.Genres.FindAsync(id)
         is Genre genre ? TypedResults.Ok(genre) : TypedResults.NotFound();
    }

    public static async Task<IResult> CreateGenre(GenreDTO genre, MovieDbContext context)
    {
        if (genre == null || genre.Name?.Length == 0) return Results.BadRequest();
        var newGenre = genre.FromDTO();
        context.Genres.Add(newGenre);
        await context.SaveChangesAsync();
        context.Entry(newGenre).State = EntityState.Detached;

        return TypedResults.Created($"/genres/{genre.Id}", newGenre.ToDTO());
    }

    public static async Task<IResult> UpdateGenre(int id, Genre genre, MovieDbContext context)
    {
        if (genre == null || genre.Name?.Length == 0 || id != genre.Id) return TypedResults.BadRequest();
        var genreDb = await context.Genres.FindAsync(id);
        if (genreDb == null) return TypedResults.NotFound();
        genreDb.Name = genre.Name;
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteGenre(int id, MovieDbContext context)
    {
        var genre = await context.Genres.FindAsync(id);
        if (genre == null) return TypedResults.NotFound();
        context.Genres.Remove(genre);
        //context.Entry(genre).State = EntityState.Deleted;
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}
