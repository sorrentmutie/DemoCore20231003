namespace DemoEFCore.Infrastructure.Movies;

public class Comment : MyEntity
{
    public string? Text { get; set; }
    public bool Reccomended { get; set; }   
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
}
