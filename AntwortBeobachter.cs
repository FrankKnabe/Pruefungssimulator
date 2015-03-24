using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    //Die Klasse des AntwortBeobachter wird von der InterfaceKlasse abgeleitet  
    public class AntwortBeobachter : IObserver<Antwort>
    {
        //Das Dispossble-Interface wird definiert
        private IDisposable unsubscriber;

        //Zur Beobachtung wird ein Abonnement auf die Klasse Antwort abgeschlossen,
        //das das Disposable-Interface initialisiert
        public virtual void Subscribe(IObservable<Antwort> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        //Mit dieser Methode werden die Abonnements wieder aufgehoben
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        //Die Methode, die den aufgenommen Datensatz zur Speicherung an die Antwortklasse
        //weitergibt
        public virtual void OnNext(Antwort value)
        {
            value.speichern(value.FragenID, value.PrüflingsID, value.Antworttext);
        }

        //Hier würden alle weitere Listen aus dewm Speicher entfernt. Da aber nur die Liste der Observer
        //erstellt wird, steht hier nichts drin.
        public virtual void OnCompleted()
        {
          
        }

        //Dinge, die bei Fehler ausgelöst werden sollen
        public virtual void OnError(Exception e)
        {
           
        }
    }

}
