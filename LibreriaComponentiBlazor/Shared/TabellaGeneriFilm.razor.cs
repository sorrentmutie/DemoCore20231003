using DemoMVC.Core.ViewModels.Movies;
using Microsoft.AspNetCore.Components;

namespace LibreriaComponentiBlazor.Shared;

public partial class TabellaGeneriFilm
{
    [Parameter]
    public List<GenresIndexViewModel> Genres { get; set; } = new();
    [Parameter]
    public EventCallback<GenresIndexViewModel> OnCancella { get; set; }
    [Parameter]
    public EventCallback<GenresIndexViewModel> OnModifica { get; set; }
}
