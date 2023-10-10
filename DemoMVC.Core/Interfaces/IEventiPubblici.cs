using DemoMVC.Core.EventiPubblici;

namespace DemoMVC.Core.Interfaces;

public interface IEventiPubblici
{
    List<EventoPubblico> EstraiEventi();
    void EliminaEvento(int id);
    void AggiungiEvento(EventoPubblico evento);
}
