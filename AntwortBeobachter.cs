using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    public class AntwortBeobachter : IObserver<Antwort>
    {
        private IDisposable unsubscriber;

        public virtual void Subscribe(IObservable<Antwort> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnNext(Antwort value)
        {
            value.speichern(value.FragenID, value.PrüflingsID, value.Antworttext);
        }

        public virtual void OnCompleted()
        {
          
        }

        public virtual void OnError(Exception e)
        {

        }
    }

}
