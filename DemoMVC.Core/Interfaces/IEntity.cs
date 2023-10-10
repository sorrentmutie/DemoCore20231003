namespace DemoMVC.Core.Interfaces;

public interface IEntity<Tkey>
{
    Tkey Id { get; set; }
}
