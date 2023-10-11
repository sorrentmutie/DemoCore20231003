using DemoMVC.Core.EventiPubblici;
using DemoMVC.Core.Interfaces;

namespace LibreriaComponentiBlazor.Services;

public class GestioneEventiFuturi : IEventiPubblici
{
    private static List<EventoPubblico> eventi = new()
    {
        new EventoPubblico { Id = 1, Name = "Corso Blazor", Date = DateTime.Today, Location = "Napoli"},
        new EventoPubblico { Id = 2, Name = "Corso Blazor Avanzato", Date = DateTime.Today.AddDays(7), Location = "Roma"}
    };

    public void AggiungiEvento(EventoPubblico evento)
    {
        eventi.Add(evento);
    }

    public void EliminaEvento(int id)
    {
        var ev = eventi.FirstOrDefault(e => e.Id == id);
        if(ev != null)
        {
            eventi.Remove(ev);
        }
    }

    public List<EventoPubblico> EstraiEventi()
    {
        return eventi;
    }
}
