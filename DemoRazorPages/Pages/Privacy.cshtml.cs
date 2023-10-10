using DemoEFCore.Infrastructure.Movies;
using DemoRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IGenreDataService dataService;

        public List<Genre>? Genres { get; set; }

        public PrivacyModel( IGenreDataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task OnGetAsync()
        {
           Genres = await dataService.GetGenres();


           // await dataService.CreateGenre("Demential Comedy");

        }
    }
}