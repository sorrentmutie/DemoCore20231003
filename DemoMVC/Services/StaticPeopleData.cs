namespace DemoMVC.Services;

public class StaticPeopleData : IPeopleData
{
    private static readonly Person[] People = new Person[]
    {
        new Person { Id = 1, Name = "John", Surname = "Doe" },
        new Person { Id = 2, Name = "Jane", Surname = "Doe" },
        new Person { Id = 3, Name = "John", Surname = "Smith" },
        new Person { Id = 4, Name = "Jane", Surname = "Smith" },
    };

    public IEnumerable<Person> GetAll()
    {
        return People;
    }
}
