using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.OleDb;

namespace PrüfungsSimulator
{
    class Antwort
    {
        //Eigenschaften der Klasse Anwort
        public int AntwortID;
        public string Antworttext;
        public int FragenID;
        public int PrüflingsID;

        //Methode zum Abspeichern der gegebenen Antworten in die Datenbank
        public void speichern(int FragenID, string Antworttext, int PrüflingsID)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();

                    con.ConnectionString = Properties.Settings.Default.cnn;
                    cmd.Connection = con;
                    //cmd.Parameters.Add()
                    //Wenn der Prüfling eine Anwort zum ersten Mal abgibt,
                    //wird die Antwort insert eingepflegt 
                    cmd.CommandText = "insert into PrüflingAntworten " +
                            "(FragenID, Antwort, PrüflingsID) values" +
                            "(" + FragenID + ", '" + Antworttext + "', " + PrüflingsID + ")";

                    con.Open();
                    try
                    {
                           cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException oex)
                    {
                        //Sollte der Datansatz schon vorhanden sein, wird ein update durchgeführt
                        if (oex.Message.StartsWith("Die Anweisung wurde beendet.\r\nVerletzung der PRIMARY KEY-Einschränkung"))
                        {
                            cmd.CommandText = "update PrüflingAntworten set Antwort = '" + Antworttext + "' where FragenID = '" + FragenID + "' and PrüflingsID = '" + PrüflingsID + "'";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }


        }

        public int id
        {
            get { return this.FragenID; }
        }

        public string atext
        {
            get { return this.Antworttext; }
        }

        public int pid
        {
            get { return this.PrüflingsID; }
        }

        //Konstruktoren
        public Antwort()
        {
            AntwortID = 0;
            Antworttext = "leer";
            FragenID = 0;
            PrüflingsID = 0;
        }
        public Antwort(int AntwortID, string Antworttext, int FragenID)
        {
            // TODO: Complete member initialization
            this.AntwortID = AntwortID;
            this.Antworttext = Antworttext;
            this.FragenID = FragenID;
        }


        public Antwort(int FragenID, string Antworttext)
        {
            this.FragenID = FragenID;
            this.Antworttext = Antworttext;
        }

        public object ausgabe()
        {return new Object();}
        //abstract public UIElement getUIElement();  
    }

    //Abgeleitete Klasse für Antworten, wo nur eine Antwort richtig ist
    class EinfachAntwort : Antwort
    {
        System.Windows.Controls.RadioButton rb =
            new System.Windows.Controls.RadioButton();
        public virtual object ausgabe()
        {
            //Radiobutton wird erzeugt und zurückgegeben
                rb.Content = Antworttext;
                return rb;
        }

       
        public EinfachAntwort(int id, string atext) : base(id, atext)
        {

        }
        
    }

    //Abgeleitete Klasse für Antworten, wo mehrere Lösungen richtig sind
    class MehrfachAntwort : Antwort
    {
        public virtual object ausgabe()
        {
            //Checkbox wird erzeugt und zurückgegeben
            System.Windows.Controls.CheckBox cb =
                new System.Windows.Controls.CheckBox();
            cb.Content = Antworttext;
            return cb;
        }

        public MehrfachAntwort(int id, string atext) : base(id, atext)
        {

        }

    }

    //Abgeleitete Klasse, in der ein Prüfling eine selber formulierte Antwort eingibt 
    class TextAntwort : Antwort
    {
        public virtual object ausgabe()
        {
            //Eine Textbox wird erzeugt und zutrückgegeben
            System.Windows.Controls.TextBox tbo =
                new System.Windows.Controls.TextBox();
            tbo.MaxLength = 100;
            tbo.Text = "";
            tbo.Width = 250;
            tbo.HorizontalAlignment = HorizontalAlignment.Left;
            return tbo;
        }

        
        public TextAntwort(int id, string atext) : base(id, atext)
        {

        }

    }

    //Diese abgeleitete Klasse ist noch nicht vollständig oder korrekt
    //Wird in Zukunft noch verändert werden
    class TKontoAntwort : Antwort 
    {
        public virtual object ausgabe()
        {
            System.Windows.Controls.Label lbl =
                new System.Windows.Controls.Label();
            lbl.Content = Antworttext;
            
            return lbl;
        }

        public object tabelle()
        {
            System.Windows.Controls.Grid grd =
                new System.Windows.Controls.Grid();
            return grd;
        }

        public TKontoAntwort(int id, string atext) : base(id, atext)
        {

        }

    }

    //public class AntwortHandler : IObservable<Antwort>
    //{
    //    List<IObserver<Antwort>> observers;

    //    public AntwortHandler()
    //    {
    //        observers = new List<IObserver<Antwort>>();
    //    }

    //    private class Unsubscriber : IDisposable
    //    {
    //        private List<IObserver<Antwort>> _observers;
    //        private IObserver<Antwort> _observer;

    //        public Unsubscriber(List<IObserver<Antwort>> observers, IObserver<Antwort> observer)
    //        {
    //            this._observers = observers;
    //            this._observer = observer;
    //        }

    //        public void Dispose()
    //        {
    //            if (!(_observer == null)) _observers.Remove(_observer);
    //        }
    //    }

    //    public IDisposable Subscribe(IObserver<Antwort> observer)
    //    {
    //        if (!observers.Contains(observer))
    //        {
    //            observers.Add(observer);

    //        }
    //        return new Unsubscriber(observers, observer);
    //    }
    //    public void GetAtext()
    //    {
    //        var datensatz = 

    //        foreach (var atext in datensatz)
    //        {

    //        }
    //    }
    //}


}
