using DemoMVC.Core.ViewModels.Movies;

namespace DemoMVC.Controllers;

public class GenresController : Controller
{
    private readonly IGenresData genresData;

    public GenresController(IGenresData genresData)
    {
        this.genresData = genresData;
    }
    public async Task<IActionResult> Index()
    {
        return View(await genresData.GetGenres());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenresCreateViewModel genre)
    {
        await genresData.CreateGenre(genre);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int id)
    {
        var genre = await genresData.GetGenre(id);
        if(genre != null)
        {
            return View(genre);
        }
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> Edit(GenresIndexViewModel genre)
    {
        await genresData.UpdateGenre(genre.Id, genre.Name!);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int id)
    {
        var genere = await genresData.GetGenre(id);
        if(genere != null)
        {
            return View(genere);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete (GenresIndexViewModel genre)
    {
        await genresData.DeleteGenre(genre.Id);
        return RedirectToAction(nameof(Index));
    }
}