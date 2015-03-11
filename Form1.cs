using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace PrüfungsSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdBegin_Click(object sender, EventArgs e)
        {
            Form2 pruefung = new Form2();
            pruefung.ShowDialog();
        }

        private void cmdEnd2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAnmeldung_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = "Provider=sqloledb; Data Source=192.168.39.130; Initial Catalog=Knabe; User ID = Knabe; Password=User2016;";

            cmd.Connection = con;
            cmd.CommandText = "select * from Prüfling where Name = '" + txtName.Text + 
                 "' and Nachname = '" + txtSurname.Text + "' and PrüflingsID = '" + txtPrueflingsID.Text + "'";

            string name = "";
            string surname = "";
            string id = "";
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();

                name = reader["Name"].ToString();
                surname = reader["Nachname"].ToString();
                id = reader["PrüflingsID"].ToString();

                if (name != "" && id != "" && surname != "")
                {
                    cmdBegin.Visible = true;
                    lblGreetings.Text += "Hallo " + name + " " + surname;
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
               
    }
}
