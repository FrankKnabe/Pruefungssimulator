using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PrüfungsSimulator
{
    class Antwort
    {

        public int AntwortID;
        public string Antworttext;
        public int FragenID;
        public Antwort()
        {
            AntwortID = 0;
            Antworttext = "leer";
            FragenID = 0;
        }
        public Antwort(int AntwortID, string Antworttext, int FragenID, string Antwortart)
        {
            // TODO: Complete member initialization
            this.AntwortID = AntwortID;
            this.Antworttext = Antworttext;
            this.FragenID = FragenID;
        }

        public Antwort(int AntwortID, string Antworttext, int FragenID)
        {
            // TODO: Complete member initialization
            this.AntwortID = AntwortID;
            this.Antworttext = Antworttext;
            this.FragenID = FragenID;
        }

        public Antwort(string Antworttext)
        {
            this.Antworttext = Antworttext;
        }
        //abstract public UIElement getUIElement();  
    }

    class EinfachAntwort : Antwort
    {
        public object ausgabe()
        {
                System.Windows.Controls.RadioButton rb =
                    new System.Windows.Controls.RadioButton();
                rb.Content = Antworttext;
                return rb;
        }

        public EinfachAntwort(string atext) : base(atext)
        {

        }
        
    }

    class MehrfachAntwort : Antwort
    {
        public object ausgabe()
        {
            System.Windows.Controls.CheckBox cb =
                new System.Windows.Controls.CheckBox();
            cb.Content = Antworttext;
            return cb;
        }

        public MehrfachAntwort(string atext) : base(atext)
        {

        }

    }

    class TextAntwort : Antwort
    {
        public object ausgabe()
        {
            System.Windows.Controls.TextBox tbo =
                new System.Windows.Controls.TextBox();
            tbo.MaxLength = 100;
            tbo.Text = "";
            tbo.Width = 250;
            tbo.HorizontalAlignment = HorizontalAlignment.Left;
            return tbo;
        }

        public TextAntwort() : base()
        {

        }

    }
    class KontoAntwort : Antwort 
    {
        public object ausgabe()
        {
            System.Windows.Controls.Label lbl =
                new System.Windows.Controls.Label();
            lbl.Content = Antworttext;
            System.Windows.Controls.Grid grd =
                new System.Windows.Controls.Grid();
            return lbl;
        }

        public KontoAntwort(string atext) : base(atext)
        {

        }
    }
}
