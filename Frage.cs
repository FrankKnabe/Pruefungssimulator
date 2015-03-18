using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    class Frage
    {
            public int FragenID;

            public string Fragetext;

            public string Fachrichtung;

            public string Fragenart;

            public int Fragenummer;

            public string ausgabe()
            {
                return "Frage " + (PrüfungsSimulator.Form2.aktFragennr+1) + ": " + Fragetext;
            }

        public Frage()
            {
                FragenID = 0;
                Fragetext = "leer";
                Fachrichtung = "leer";
                Fragenummer = 0;
            }
        public Frage(int id, string fragetext, string fach, string fart, int fnr)
        {
            FragenID = id;
            Fragetext = fragetext;
            Fachrichtung = fach;
            Fragenart = fart;
            Fragenummer = fnr;
        }

        public Frage(int id, string fragetext, string fach, string fart)
        {
            FragenID = id;
            Fragetext = fragetext;
            Fachrichtung = fach;
            Fragenart = fart;
        }
       
    }
}
