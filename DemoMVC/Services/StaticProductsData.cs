namespace DemoMVC.Services;

public class StaticProductsData : IProductsData
{
    public int GetNumberOfProducts()
    {
        return 42;
    }
}
