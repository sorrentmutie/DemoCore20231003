using DemoMVC.Core.ViewModels.Northwind;

namespace DemoMVC.Core.Interfaces.Northwind;

public interface ICategoriesData
{
    IEnumerable<CategoryViewModel> GetCategories();
}
