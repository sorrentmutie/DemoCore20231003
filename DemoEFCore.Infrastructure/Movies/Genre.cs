using DemoMVC.Core.Interfaces;

namespace DemoEFCore.Infrastructure.Movies;

public class Genre: IEntity<int>
{
    public string? Name { get; set; }
    public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    public int Id { get; set; }
}
