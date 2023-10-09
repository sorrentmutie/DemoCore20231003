using DemoMVC.Core.ViewModels.Movies;

namespace DemoMVC.Services.Movies;

public class GenresDatabaseService : IGenresData
{
    private readonly MovieDbContext movieDbContext;

    public GenresDatabaseService(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }

    public async Task<int> CreateGenre(GenresCreateViewModel model)
    {
        var newGenre = new Genre { Name = model.Name};
        movieDbContext.Genres.Add(newGenre);
        await movieDbContext.SaveChangesAsync();
        return newGenre.Id;
    }

    public async Task DeleteGenre(int id)
    {
        var genre = await movieDbContext.Genres.FindAsync(id);
        if(genre != null)
        {
            movieDbContext.Genres.Remove(genre);
            await movieDbContext.SaveChangesAsync();
        }
    }

    public async Task<GenresIndexViewModel?> GetGenre(int id)
    {
        var movieGenre = await movieDbContext.Genres.FindAsync(id);
        if (movieGenre != null)
        {
            return new GenresIndexViewModel { Id = movieGenre.Id, Name = movieGenre.Name };
        } else
        {
            return null;
        }
    }

   
    public async Task UpdateGenre(int id, string name)
    {
        var genre = await movieDbContext.Genres.FindAsync(id);
        if (genre != null)
        {
            genre.Name = name;
            movieDbContext.Genres.Update(genre);
            await movieDbContext.SaveChangesAsync();
        }
    }

    public async Task<List<GenresIndexViewModel>?> GetGenres()
    {

        return await movieDbContext.Genres
             .Select(genre => new GenresIndexViewModel
             {
                 Id = genre.Id,
                 Name = genre.Name
             })
             .ToListAsync();

    }
}
