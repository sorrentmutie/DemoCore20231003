using DemoMVC.Core.ViewModels.Movies;

namespace DemoMVC.Core.Interfaces.Movies;

public interface IGenresData
{
    Task<List<GenresIndexViewModel>?> GetGenres();
    Task<GenresIndexViewModel?> GetGenre(int id);
    Task<int> CreateGenre(GenresCreateViewModel model);
    Task DeleteGenre(int id);
    Task UpdateGenre(int id, string name);
    void Cancel();
}
