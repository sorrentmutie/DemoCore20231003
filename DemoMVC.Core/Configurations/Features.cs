namespace DemoMVC.Core.Configurations;

public class Features
{
    public const string Personalize =nameof(Personalize);
    public const string Recommender = nameof(Recommender);

    public bool Enabled { get; set; }
    public string? ApiKey { get; set; }
}
