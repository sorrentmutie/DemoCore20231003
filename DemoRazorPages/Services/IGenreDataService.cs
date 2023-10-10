using DemoEFCore.Infrastructure.Movies;

namespace DemoRazorPages.Services
{
    public interface IGenreDataService
    {
        Task<List<Genre>> GetGenres();
        Task CreateGenre(string name);
    }
}