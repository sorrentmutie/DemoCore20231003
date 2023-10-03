using DemoMVC.Core.Interfaces;

namespace DemoMVC.Controllers;

public class PeopleController : Controller
{
    private readonly IPeopleData peopleData;

    public PeopleController(IPeopleData peopleData)
    {
        this.peopleData = peopleData;  
    }

    public IActionResult Index()
    {
        return View(peopleData.GetAll());
    }

    //
}
