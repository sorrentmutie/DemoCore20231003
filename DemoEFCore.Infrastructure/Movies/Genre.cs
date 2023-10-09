namespace DemoEFCore.Infrastructure.Movies;

public class Genre: MyEntity
{
    public string? Name { get; set; }
    public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
}
