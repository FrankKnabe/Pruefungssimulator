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
        public Form2()
        {
            InitializeComponent();
        }

        int aktFragennr = 0;

        List<Frage> fragen = new List<Frage>();
        List<Antwort> antworten = new List<Antwort>();
        //ArrayList fragen = new ArrayList();
        //ArrayList antworten = new ArrayList();

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = "Provider=sqloledb; Data Source=192.168.39.130; Initial Catalog=Knabe; User ID = Knabe; Password=User2016;";

            cmd.Connection = con;
            cmd.CommandText = "select * from Fragenpool";

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                //int i;

                while(reader.Read())
                {
                    fragen.Add(new Frage(Convert.ToInt32(reader["fragenid"].ToString()), reader["frage"].ToString(), reader["fachrichtung"].ToString(), reader["fragenart"].ToString()));
                    //lst.Add(new Frage(Convert.ToInt32(reader["fragenid"].ToString()), reader["frage"].ToString(), reader["fachrichtung"].ToString(), reader["fragenart"].ToString()));
                }
                //Frage fr =  Frage lst[0];
                lblFrage.Text = fragen[0].ausgabe();
                reader.Close();

                cmd.CommandText = "select * from antwortenpool";
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    antworten.Add(new Antwort(Convert.ToInt32(reader["antwortid"].ToString()), reader["antworten"].ToString(), Convert.ToInt32(reader["fragenid"].ToString())));
                }
                AntwortSuchen(fragen, antworten);
                //AntwortHinzufuegen(fragen, antworten);

                reader.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }


        }

        private void cmdWeiter_Click(object sender, EventArgs e)
        {
            if (++aktFragennr == fragen.Count-1)
            {
                cmdWeiter.Enabled = false;
                cmdEnd.Enabled = true;
            }
            else
            {
                cmdZurueck.Enabled = true;
            }
            //Frage fr = (Frage)fragen[aktFragennr];
            lblFrage.Text = fragen[aktFragennr].ausgabe();
            AntwortSuchen(fragen, antworten);
            //AntwortHinzufuegen(fragen, antworten);
            

            
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
            //Frage fr = (Frage)fragen[aktFragennr];
            lblFrage.Text = fragen[aktFragennr].ausgabe();
            AntwortSuchen(fragen, antworten);
            //AntwortHinzufuegen(fragen, antworten);

        }

        private void cmdEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AntwortSuchen(List<Frage> query, List<Antwort> answer)
        {
            ArrayList text = new ArrayList();
            for(int i = 0; i < answer.Count; i++)
            {
                //Antwort an = (Antwort)answer[j];
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
            //Frage fr = (Frage)query[aktFragennr];


            StackPanel sp = new StackPanel();
            for (int i = 0; i < answer.Count; i++)
            {
                
                if (query[aktFragennr].Fragenart == "Einfach")
                {
                    string atext = answer[i].ToString();
                    EinfachAntwort ean = new EinfachAntwort(atext);
                    sp.Children.Add((System.Windows.Controls.RadioButton)ean.ausgabe());
                }
                else if (query[aktFragennr].Fragenart == "Mehrfach")
                {
                    string atext = answer[i].ToString();
                    MehrfachAntwort man = new MehrfachAntwort(atext);
                    sp.Children.Add((System.Windows.Controls.CheckBox)man.ausgabe());
                }
                else if (query[aktFragennr].Fragenart == "Text")
                {
                    TextAntwort tan = new TextAntwort();
                    sp.Children.Add((System.Windows.Controls.TextBox)tan.ausgabe());
                }
                else if(query[aktFragennr].Fragenart == "Konto")
                {
                    string atext = answer[i].ToString();
                    KontoAntwort kan = new KontoAntwort(atext);
                    sp.Children.Add((System.Windows.Controls.Label)kan.ausgabe());
                    sp.Children.Add((System.Windows.Controls.Grid)kan.tabelle());
                }
            }
            eHost1.Child = sp;
        }
            
     }
}
