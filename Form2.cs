using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PrüfungsSimulator
{

    public partial class Form2 : Form
    {
        //Übernahme der PrüflingsID von der Eingabemaske
        static int pid = PrüfungsSimulator.Form1.id;

        int randomnumber;
        Random rnd = new Random();
        static int fid;
        static string atext;
        StackPanel sp = new StackPanel();
        AntwortHandler provider = new AntwortHandler();
        AntwortBeobachter observer = new AntwortBeobachter();

        public Form2()
        {
            InitializeComponent();
        }

        //Static damit von der Klasse Frage aus auf diese Variable zugegriffen werden kann
        public static int aktFragennr = 0;

        //Initialisierung der Listen zur Aufnahme der Klassen
        List<Frage> tmpfragen = new List<Frage>();
        List<Frage> fragen = new List<Frage>();
        List<Antwort> antworten = new List<Antwort>();
        List<Loesung> loesungen = new List<Loesung>();

        
        private void Form2_Load(object sender, EventArgs e)
        {
            //Beim Laden der Form2 werden die Datensätze aus der Datenbank 
            //in die Klassen und diese in die Listen gepflegt 
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = Properties.Settings.Default.cnn;

            cmd.Connection = con;
            cmd.CommandText = "select * from Fragenpool";

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                //Die Fragen werden in ein temporäre Liste eingelesen 
                while (reader.Read())
                {
                    tmpfragen.Add(new Frage(Convert.ToInt32(reader["fragenid"].ToString()), reader["frage"].ToString(), reader["fachrichtung"].ToString(), reader["fragenart"].ToString()));
                }


                //Die temporären Fragen werden nun in zufällige Reihefolge in die
                //tatsächliche Fragenliste eingetragen
                while(tmpfragen.Count != 0)
                {
                    randomnumber = rnd.Next(0, tmpfragen.Count);
                    //fragen.Add(new Frage(tmpfragen[randomnumber].FragenID, tmpfragen[randomnumber].Fragetext, tmpfragen[randomnumber].Fachrichtung, tmpfragen[randomnumber].Fragenart));
                    fragen.Add(tmpfragen[randomnumber]);
                    tmpfragen.RemoveAt(randomnumber);
                }

                //Die erste Frage wird ausgelesen und an die Methode Ausgabe
                //der Klasse Fragen übergeben
                lblFrage.Text = fragen[aktFragennr].ausgabe();
                reader.Close();

                cmd.CommandText = "select * from antwortenpool";
                reader = cmd.ExecuteReader();

                //Nun werden die Antworten aus der Datenbank in eine Liste abgespeichert
                while (reader.Read())
                {
                    antworten.Add(new Antwort(Convert.ToInt32(reader["antwortid"].ToString()), reader["antworten"].ToString(), Convert.ToInt32(reader["fragenid"].ToString())));
                }
                AntwortSuchen(fragen, antworten);

                reader.Close();

                cmd.CommandText = "select * from lösungen";
                reader = cmd.ExecuteReader();

                //Hier werden die richtigen Antworten zum späteren Vergleich der gegebenen Antworten
                //in eine Liste gelesen
                while (reader.Read())
                {
                    loesungen.Add(new Loesung(Convert.ToInt32(reader["fragenid"].ToString()), reader["antworten"].ToString()));
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            //Die gegebene Antwort wird zum Speichern weitergegeben
            AntwortSichern();

            //Es wird verglichen ob die um 1 erhöhte Fragenummer mit der um
            //1 reduzierte Anzahl der Fragen übereinstimmt
            if (++aktFragennr == fragen.Count - 1)
            {
                //Sollte dies der Fall sein, wird der Weiter-Button deaktiviert
                //und der Beenden-Button aktiviert
                cmdWeiter.Enabled = false;
                cmdEnd.Enabled = true;
            }
            else
            {
                //Falls nicht, wird der Zurück-Button aktiv gemnacht
                cmdZurueck.Enabled = true;
            }

            //Die nächste Frage wird geladen
            lblFrage.Text = fragen[aktFragennr].ausgabe();
            //Die passende Antwort dazu auch
            AntwortSuchen(fragen, antworten);

        }

        private void cmdZurueck_Click(object sender, EventArgs e)
        {
            //Wird der Zurück-Button betätigt, wird die Fragenummer um 1 reduziert
            aktFragennr--;

            //Es wird geprüft, ob die Fragenummer kleiner oder gleich 0 ist
            if (aktFragennr <= 0)
            {
                //Sollte dies der Fall sein, wird der Zurück-Button deaktiviert
                //und der Weiter-Button aktiviert
                cmdZurueck.Enabled = false;
                cmdWeiter.Enabled = true;
            }
            else
            {
                //Sonst sind beide Buttons aktiv
                cmdZurueck.Enabled = true;
                cmdWeiter.Enabled = true;
            }
            lblFrage.Text = fragen[aktFragennr].ausgabe();
            AntwortSuchen(fragen, antworten);

        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            //Wenn die Prüfung beendet wird, kommt die zuletzt gegebene Antwort
            //zur Speicherung in die entsprechende Methode der Antwort-Klasse
            AntwortSichern();

            //Die Methode zum Vergleich der gegebenen Antwort mit den richtigen Antworten wird angestossen
            ErgebnisBerechnung(loesungen);
            observer.Unsubscribe();
            provider.Pruefungsende();

            Close();
        }

        private void AntwortSuchen(List<Frage> query, List<Antwort> answer)
        {
            //Initialisierung der Arrayliste für die Aufnahme der Antworttexte
            ArrayList text = new ArrayList();

            //Die Antwortliste wird durchgesehen
            for (int i = 0; i < answer.Count; i++)
            {
                int id = answer[i].AntwortID;
                int fid = answer[i].FragenID;

                //Die IDs der Antworten werden mit der IDs der Fragen verglichen
                //Bei übereinstimmung wird der Antworttext in die Arrayliste 
                //abgelegt
                if (answer[i].FragenID == query[aktFragennr].FragenID)
                {
                    text.Add(answer[i].Antworttext);
                }
            }

            //Nun werden die Antworttexte in gegebener Reihenfolge der Methode 
            //zur Antworterzeugung in Form2 weitergegeben
            for (int j = 0; j < text.Count; j++)
            {
                AntwortHinzufuegen(fragen, text);
            }

        }

        //Methode zur Antworterzeugung in Form2
        private void AntwortHinzufuegen(List<Frage> query, ArrayList answer)
        {
            //Zuerst wird das StachPanel geleert 
            sp.Children.Clear();

            //Nun wird die Arrayliste mit den passenden Antworten abgearbeitet
            for (int i = 0; i < answer.Count; i++)
            {
                //Je nach Fragenart wird ein Antworttext zum passenden Steuerelement
                //hinzugefügt
                int id = query[aktFragennr].FragenID;
                string atext = answer[i].ToString();
                //Der Klassenname wird dem Assemblynamen und der Fragenart zusammen gestellt
                string ClassName = "PrüfungsSimulator." + query[aktFragennr].Fragenart;
                //Es wird eine Instanz ant erzeugt, die einen Konstruktor aufruft, der die passenden
                //Steuerelemente in das Antwortfeld implementiert
                Antwort ant = (Antwort)Activator.CreateInstance(Type.GetType(ClassName), new object[] { id, atext });
                //Die Steuerelemente werden zum StackPanel hinzugefügt
                sp.Children.Add(ant.ausgabe());
            }
            //Das StackPanel wird in die Groupbox eingefügt 
            eHost1.Child = sp;
        }

        //Methode zur Abspeicherung der gegebenen Antwort
        public void AntwortSichern()
        {
            fid = fragen[aktFragennr].FragenID;
            //Die Antworten, die gespeichert werden sollen, sind von den Events der
            //der verschiedenen Fragenarten, sprich verwendeten Steuerelementen, abhängig
            if (fragen[aktFragennr].Fragenart == "EinfachAntwort")
            {
                //Jedes Radiobutton wird geprüft, ob es markiert ist oder nicht
                foreach (System.Windows.Controls.RadioButton rb in this.sp.Children)
                {
                    //Falls das der Fall ist, wird der Antworttext mit ID der Frage
                    //und des Prüflings an die Methode speichern der Klasse Antwort 
                    //weitergereicht
                    if (rb.IsChecked == true)
                    {
                        atext = rb.Content.ToString();
                    }
                }
            }
                //Hier wird das Gleiche getan mit den Checkboxen
            else if (fragen[aktFragennr].Fragenart == "MehrfachAntwort")
            {
                //jedoch muss der Antworttext vorher gelöscht werden, da
                //sonst die Antworten nicht korrekt übergeben wird
                atext = "";
                foreach (System.Windows.Controls.CheckBox cb in this.sp.Children)
                {
                    if (cb.IsChecked == true)
                    {
                        //Da mehrere Antworten möglich sind
                        //werden sie zur besseren Lesbarkeit mit einem
                        //Semikolon getrennt
                        atext += cb.Content.ToString() + ";";
                    }
                }
            }
                //Hier wird der Inhalt der Textboxen (später sollen auch mal mehrere Textboxen
                //möglich sein), an die entsprechende Methode der Antwort-Klasse 
                //übergeben werden
            else if (fragen[aktFragennr].Fragenart == "TextAntwort")
            {
                foreach (System.Windows.Controls.TextBox tbo in this.sp.Children)
                {
                    atext = tbo.Text;
                }
            }
            observer.Subscribe(provider);
            provider.GetAtext(fid, pid, atext);
        }
        //Methode zum Vergleich der gegebenen Antworten mit den richtigen Lösungen
        private  void ErgebnisBerechnung(List<Loesung> rightanswers)
        {
            //Anzahl der richtigen Antwort initialisiert
            int anzahlRichtig = 0;
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            //Liste der vom Prüfling gegebenen Antworten wird initialisiert
            List<Loesung> pruefling = new List<Loesung>();

            con.ConnectionString = Properties.Settings.Default.cnn;

            cmd.Connection = con;
            cmd.CommandText = "select * from PrüflingAntworten where PrüflingsID = " + pid + "";

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                //Die vom Prüfling gegebenen Antworten werden von der Datenbank 
                // in die Liste eingelesen
                while (reader.Read())
                {
                    pruefling.Add(new Loesung(Convert.ToInt32(reader["fragenid"].ToString()),reader["antwort"].ToString(), Convert.ToInt32(reader["prüflingsid"].ToString())));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Die Liste wird abgearbeitet
            for(int i = 0; i < pruefling.Count ; i++)
            {
                //Für jede übereinstimmende Antwort wird der Zähler um 1 erhöht
                if (loesungen[i].FragenID == pruefling[i].FragenID && loesungen[i].Antwort == pruefling[i].Antwort)
                {
                    anzahlRichtig++;
                }
            }

            //Das Ergebnis wird dem Prüfling angezeigt
            MessageBox.Show("Sie haben " + anzahlRichtig + " von " + pruefling.Count + " Fragen richtig beantwortet.");
        }

    }
}
