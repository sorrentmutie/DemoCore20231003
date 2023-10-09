namespace DemoEFCore.Infrastructure.Movies;

public class Movie: MyEntity
{
    public bool IsReleased { get; set; }
    public DateTime ReleaseDate { get; set; }   
    public string? Title { get; set; }
    public string? Description { get; set; }
    public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();
    public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
}
