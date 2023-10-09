using DemoMVC.Core.Interfaces.Northwind;
using DemoMVC.Core.ViewModels.Northwind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoriesData categoriesData;

        public List<CategoryViewModel>? Categories { get; set; }

        public IndexModel(ICategoriesData categoriesData)
        {
            this.categoriesData = categoriesData;
        }

        public void OnGet()
        {
            Categories = categoriesData
                .GetCategories()
                .ToList();
        }
    }
}