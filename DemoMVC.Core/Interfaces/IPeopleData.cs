using DemoMVC.Core.Entities;

namespace DemoMVC.Core.Interfaces;

public  interface IPeopleData
{
    IEnumerable<Person> GetAll();
}
