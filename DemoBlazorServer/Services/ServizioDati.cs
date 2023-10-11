using DemoEFCore.Infrastructure.Movies;
using DemoMVC.Core.Interfaces.Movies;
using DemoMVC.Core.ViewModels.Movies;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServer.Services;

public class ServizioDati : IGenresData
{
    private MovieDbContext movieDbContext;

    public ServizioDati(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateGenre(GenresCreateViewModel model)
    {
        var genre = new Genre
        {
            Name = model.Name
        };
        movieDbContext.Genres.Add(genre);

        await movieDbContext.SaveChangesAsync();
        movieDbContext.Entry(genre).State = EntityState.Detached;
        return genre.Id;
    }

    public async Task DeleteGenre(int id)
    {
        var genre = new Genre
        {
            Id = id
        };
       
        movieDbContext.Genres.Remove(genre);
        await movieDbContext.SaveChangesAsync();
    }

    public Task<GenresIndexViewModel?> GetGenre(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GenresIndexViewModel>?> GetGenres()
    {
        return await movieDbContext.Genres
            .Select(g => new GenresIndexViewModel
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToListAsync();
    }

    public async Task UpdateGenre(int id, string name)
    {
        var genre = new Genre
        {
            Id = id,
            Name = name
        };
        movieDbContext.Genres.Update(genre);
        await movieDbContext.SaveChangesAsync();
    }
}
