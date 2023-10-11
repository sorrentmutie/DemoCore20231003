using DemoEFCore.Infrastructure.Movies;
using DemoMVC.Core.Interfaces.Movies;
using DemoMVC.Core.ViewModels.Movies;
using System.Net.Http.Json;
using System.Numerics;

namespace DemoBlazorWASM.Services
{
    public class ServizioDatiGeneri : IGenresData
    {
        private readonly IHttpClientFactory httpClientFactory;
        private CancellationTokenSource? cancellationTokenSource;

        public ServizioDatiGeneri(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void Cancel()
        {
            cancellationTokenSource?.Cancel();
        }

        public async Task<int> CreateGenre(GenresCreateViewModel genre)
        {
            var httpClient = httpClientFactory.CreateClient("genres");

            var response = await httpClient.PostAsJsonAsync("genres", genre);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<GenresIndexViewModel>();
                if(content != null)
                {
                    return content.Id;
                }
                else
                {
                    return -2;
                }
            } else
            {
                return -1;
            }
        }

        public async Task DeleteGenre(int id)
        {
            var httpClient = httpClientFactory.CreateClient("genres");
            await httpClient.DeleteAsync($"genres/{id}");
        }

        public Task<GenresIndexViewModel?> GetGenre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenresIndexViewModel>?> GetGenres()
        {
            var httpClient = httpClientFactory.CreateClient("genres");

            cancellationTokenSource = new CancellationTokenSource();

            var response = await httpClient.GetAsync("genres", HttpCompletionOption.ResponseHeadersRead,
                cancellationTokenSource.Token);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync
                    <List<GenresIndexViewModel>>();
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateGenre(int id, string name)
        {
            var httpClient = httpClientFactory.CreateClient("genres");
            await httpClient.PutAsJsonAsync($"genres/{id}", new Genre { Id = id, Name = name });
        }
    }
}
