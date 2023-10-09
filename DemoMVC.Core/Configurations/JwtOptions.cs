namespace DemoMVC.Core.Configurations;

public class MyJwtOptions
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? SecretKey { get; set; }
}
