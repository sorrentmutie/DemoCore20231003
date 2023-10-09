namespace DemoEFCore.Infrastructure.Movies;

public class Actor: MyEntity
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
}
