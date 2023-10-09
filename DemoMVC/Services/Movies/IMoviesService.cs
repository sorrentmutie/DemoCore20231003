namespace DemoMVC.Services.Movies
{
    public interface IMoviesService
    {
        Task AddMovieWithComments(Movie movie);
    }
}