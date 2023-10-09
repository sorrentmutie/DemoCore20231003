using DemoMVC.Core.Interfaces.Northwind;
using DemoMVC.Core.ViewModels.Northwind;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPages.Services;

public class CategoriesService : ICategoriesData
{
    private readonly NorthwindContext context;

    public CategoriesService(NorthwindContext context)
    {
        this.context = context;
    }

    public IEnumerable<CategoryViewModel> GetCategories()
    {
       
        return  context.Categories
                .Include(c => c.Products)     
                .ThenInclude(x => x.Supplier)
                
                .Select( c => new CategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    ProductCount = c.Products.Count()
                });
    }
}
