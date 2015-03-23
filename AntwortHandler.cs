using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    //Erstellen einer Klasse AntwortHandler, die die Antworten des Prüflings
    //beobachtet und dem AntwortBeobachter mitteilt, das etwas zum speichern da ist.
    //Sie wird vom Interfaceklasse IObservable abgeleitet.
    public class AntwortHandler : IObservable<Antwort>
    {
        //Es werden Listen für den Beobachter und  der Antworten erstellt
        List<IObserver<Antwort>> observers;
        List<Antwort> antworten;

        //Konstruktor
        public AntwortHandler()
        {
            observers = new List<IObserver<Antwort>>();
            antworten = new List<Antwort>();
        }

        //Die Private Klasse Unsubscriber soll nicht benötigte Beobachter
        // aus der Liste entfernen
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Antwort>> _observers;
            private IObserver<Antwort> _observer;

            public Unsubscriber(List<IObserver<Antwort>> observers, IObserver<Antwort> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            //Diese Methode entfernt den Beobachter 
            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        //Mit diesem Interface wird ein Beobachter angelegt
        public IDisposable Subscribe(IObserver<Antwort> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

        //Hier 
        public void GetAtext(int id, int pid, string atext)
        {
            var datensatz = new Antwort(id, pid, atext );

            foreach (var observer in observers)
            {
                observer.OnNext(datensatz);
            }
        }

        public void Pruefungsende()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }

            observers.Clear();
        }
    }
}
