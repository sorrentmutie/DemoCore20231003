using DemoEFCore.Infrastructure.Movies;
using DemoMVC.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPages.Services
{
    public class GenreDataService : IGenreDataService
    {
        private readonly IRepository<Genre, int> repository;

        public GenreDataService(IRepository<Genre, int> repository)
        {
            this.repository = repository;
        }

        public async Task CreateGenre(string name)
        {
           await repository.CreateAsync(new Genre { Name = name });
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await repository.GetAll()
                .OrderBy(x => x.Name)
               
                .Skip(3)
                .Take(2)
                //.Where( x=> x.Name.Length > 6)
                .ToListAsync();
        }

    }
}
