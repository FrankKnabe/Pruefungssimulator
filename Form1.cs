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
               
    }
}
