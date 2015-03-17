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

        public int AntwortID;
        public string Antworttext;
        public int FragenID;
        public int PrüflingsID;

        public void speichern(int FragenID, string Antworttext, int PrüflingsID)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    //OleDbDataReader reader;

                    con.ConnectionString = Properties.Settings.Default.cnn;
                    cmd.Connection = con;
                    //cmd.Parameters.Add()
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
        public Antwort()
        {
            AntwortID = 0;
            Antworttext = "leer";
            FragenID = 0;
            PrüflingsID = 0;
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

        public Antwort(int FragenID, string Antworttext)
        {
            this.FragenID = FragenID;
            this.Antworttext = Antworttext;
        }


        //abstract public UIElement getUIElement();  
    }

    class EinfachAntwort : Antwort
    {
        System.Windows.Controls.RadioButton rb =
            new System.Windows.Controls.RadioButton();
        public object ausgabe()
        {

                rb.Content = Antworttext;
                return rb;
        }

       
        public EinfachAntwort(int id, string atext) : base(id, atext)
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

        public MehrfachAntwort(int id, string atext) : base(id, atext)
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

        
        public TextAntwort(int id, string atext) : base(id, atext)
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
            
            return lbl;
        }

        public object tabelle()
        {
            System.Windows.Controls.Grid grd =
                new System.Windows.Controls.Grid();
            return grd;
        }

        public KontoAntwort(int id, string atext) : base(id, atext)
        {

        }
    }

    public class AntwortAnnahme : EventArgs
    {
        public AntwortAnnahme(int id, string atext, int pid)
        {
            sid = id;
            satext = atext;
            spid = pid;
        }
        private int sid;
        private string satext;
        private int spid;

        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        public string Satext
        {
            get { return satext; }
            set { satext = value; }
        }

        public int Spid
        {
            get { return spid; }
            set { spid = value; }
        }
    }
}
