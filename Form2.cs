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
        int pid = PrüfungsSimulator.Form1.id;
        int id;
        int fid;
        string atext;
        StackPanel sp = new StackPanel();
        Antwort Ant = new Antwort();

        public Form2()
        {
            InitializeComponent();
        }

        int aktFragennr = 0;

        List<Frage> fragen = new List<Frage>();
        List<Antwort> antworten = new List<Antwort>();
        List<Loesung> loesungen = new List<Loesung>();

        
        private void Form2_Load(object sender, EventArgs e)
        {
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

                while (reader.Read())
                {
                    fragen.Add(new Frage(Convert.ToInt32(reader["fragenid"].ToString()), reader["frage"].ToString(), reader["fachrichtung"].ToString(), reader["fragenart"].ToString()));
                }
                lblFrage.Text = fragen[0].ausgabe();
                reader.Close();

                cmd.CommandText = "select * from antwortenpool";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    antworten.Add(new Antwort(Convert.ToInt32(reader["antwortid"].ToString()), reader["antworten"].ToString(), Convert.ToInt32(reader["fragenid"].ToString())));
                }
                AntwortSuchen(fragen, antworten);

                reader.Close();

                cmd.CommandText = "select * from lösungen";
                reader = cmd.ExecuteReader();

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

            AntwortSichern();
            

            if (++aktFragennr == fragen.Count - 1)
            {
                cmdWeiter.Enabled = false;
                cmdEnd.Enabled = true;
            }
            else
            {
                cmdZurueck.Enabled = true;
            }

            lblFrage.Text = fragen[aktFragennr].ausgabe();
            AntwortSuchen(fragen, antworten);

        }

        private void cmdZurueck_Click(object sender, EventArgs e)
        {
            aktFragennr--;
            if (aktFragennr <= 0)
            {
                cmdZurueck.Enabled = false;
                cmdWeiter.Enabled = true;
            }
            else
            {
                cmdZurueck.Enabled = true;
                cmdWeiter.Enabled = true;
            }
            lblFrage.Text = fragen[aktFragennr].ausgabe();
            AntwortSuchen(fragen, antworten);

        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {

            AntwortSichern();
            ErgebnisBerechnung(loesungen);

            Close();
        }

        private void AntwortSuchen(List<Frage> query, List<Antwort> answer)
        {
            ArrayList text = new ArrayList();
            for (int i = 0; i < answer.Count; i++)
            {
                int id = answer[i].AntwortID;
                int fid = answer[i].FragenID;
                if (answer[i].FragenID == query[aktFragennr].FragenID)
                {
                    text.Add(answer[i].Antworttext);
                }
            }
            for (int j = 0; j < text.Count; j++)
            {
                AntwortHinzufuegen(fragen, text);
            }

        }
        private void AntwortHinzufuegen(List<Frage> query, ArrayList answer)
        {

            sp.Children.Clear();
            for (int i = 0; i < answer.Count; i++)
            {

                if (query[aktFragennr].Fragenart == "Einfach")
                {
                    int id = query[aktFragennr].FragenID;
                    string atext = answer[i].ToString();
                    EinfachAntwort ean = new EinfachAntwort(id, atext);
                    sp.Children.Add((System.Windows.Controls.RadioButton)ean.ausgabe());


                }
                else if (query[aktFragennr].Fragenart == "Mehrfach")
                {
                    int id = query[aktFragennr].FragenID;
                    string atext = answer[i].ToString();
                    MehrfachAntwort man = new MehrfachAntwort(id, atext);
                    sp.Children.Add((System.Windows.Controls.CheckBox)man.ausgabe());
                }
                else if (query[aktFragennr].Fragenart == "Text")
                {
                    int id = query[aktFragennr].FragenID;
                    string atext = "";
                    TextAntwort tan = new TextAntwort(id, atext);
                    atext = tan.Antworttext;
                    sp.Children.Add((System.Windows.Controls.TextBox)tan.ausgabe());
                }
                else if (query[aktFragennr].Fragenart == "Konto")
                {
                    int id = query[aktFragennr].FragenID;
                    string atext = answer[i].ToString();
                    KontoAntwort kan = new KontoAntwort(id, atext);
                    sp.Children.Add((System.Windows.Controls.Label)kan.ausgabe());
                    sp.Children.Add((System.Windows.Controls.Grid)kan.tabelle());
                }
            }
            eHost1.Child = sp;
        }

        public void AntwortSichern()
        {
            if (fragen[aktFragennr].Fragenart == "Einfach")
            {
                foreach (System.Windows.Controls.RadioButton rb in this.sp.Children)
                {
                    if (rb.IsChecked == true)
                    {
                        fid = fragen[aktFragennr].FragenID;
                        atext = rb.Content.ToString();
                        Ant.speichern(fid, atext, pid);
                    }
                }
            }
            else if (fragen[aktFragennr].Fragenart == "Mehrfach")
            {
                atext = "";
                foreach (System.Windows.Controls.CheckBox cb in this.sp.Children)
                {
                    if (cb.IsChecked == true)
                    {
                        fid = fragen[aktFragennr].FragenID;
                        atext += cb.Content.ToString() + ";";
                        Ant.speichern(fid, atext, pid);
                    }
                }
            }
            else if (fragen[aktFragennr].Fragenart == "Text")
            {
                foreach (System.Windows.Controls.TextBox tbo in this.sp.Children)
                {
                    fid = fragen[aktFragennr].FragenID;
                    atext = tbo.Text;
                    //MessageBox.Show(atext + "\n" + fid + "\n" + pid);
                    Ant.speichern(fid, atext, pid);
                }
            }
        }

        private  void ErgebnisBerechnung(List<Loesung> rightanswers)
        {

            int anzahlRichtig = 0;
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;
            List<Loesung> pruefling = new List<Loesung>();

            con.ConnectionString = Properties.Settings.Default.cnn;

            cmd.Connection = con;
            cmd.CommandText = "select * from PrüflingAntworten where PrüflingsID = " + pid + "";

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

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

            for(int i = 0; i < pruefling.Count ; i++)
            {
                if (loesungen[i].FragenID == pruefling[i].FragenID && loesungen[i].Antwort == pruefling[i].Antwort)
                {
                    anzahlRichtig++;
                }
            }

            MessageBox.Show("Sie haben " + anzahlRichtig + " von " + pruefling.Count + " Fragen richtig beantwortet.");
        }
    }
}
