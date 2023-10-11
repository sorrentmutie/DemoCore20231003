using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.ViewModels.Movies;

public class GenresIndexViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il campo {0} è obbligatorio")]
    [StringLength(10, ErrorMessage = "Il campo {0} deve essere lungo al massimo {1} caratteri")]
    public string? Name { get; set; }
}

public class GenresCreateViewModel
{
    public string? Name { get; set; }
}   