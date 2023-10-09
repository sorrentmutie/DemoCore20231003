using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.Configurations;

public class MyCustomSettings
{
    [Range(0,100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public required int Scale { get; set; }

    public required int VerbosityLevel { get; set; }

    [RegularExpression(@"[\w\d]{2,18}")]
    public required string? SiteTitle { get; set; }
}




