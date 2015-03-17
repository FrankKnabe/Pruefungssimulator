using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    class Loesung
    {
        public int FragenID;
        public string Antwort;
        public int PrüflingsID;

        public Loesung ()
        {
            FragenID = 0;
            Antwort = "";
        }

        public Loesung(int id, string atext)
        {
            FragenID = id;
            Antwort = atext;
        }

        public Loesung(int id, string atext, int pid)
        {
            FragenID = id;
            Antwort = atext;
            PrüflingsID = pid;
        }
    }
}
