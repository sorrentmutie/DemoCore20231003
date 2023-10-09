namespace DemoMVC.Services.Movies;

public class MoviesService : IMoviesService
{
    private readonly MovieDbContext movieDbContext;

    public MoviesService(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }

    public async Task AddMovieWithComments(Movie movie)
    {
       movieDbContext.Movies.Add(movie);  
       await movieDbContext.SaveChangesAsync();
    }

}
