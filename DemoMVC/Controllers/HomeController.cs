using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace DemoMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMoviesService moviesService;

    public HomeController(ILogger<HomeController> logger,
        IMoviesService moviesService)
    {
        _logger = logger;
        this.moviesService = moviesService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        var newMovie = new Movie
        {
            Description = "A second new movie",
            IsReleased = true,
            ReleaseDate = DateTime.Now.AddDays(-4),
            Title = "Film da piangere",
            Comments = new HashSet<Comment> {
                new Comment { Reccomended = true, Text = "Beatiful" },
                new Comment { Reccomended = false, Text = "Touching" }},
            Genres = new HashSet<Genre>
            {
                new Genre { Name = "Sentimental" }
            }
        };
        await moviesService.AddMovieWithComments(newMovie);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}