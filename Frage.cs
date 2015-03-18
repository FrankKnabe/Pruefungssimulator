using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrüfungsSimulator
{
    class Frage
    {
        //Initialisierung der Eigenschaften
            public int FragenID;

            public string Fragetext;

            public string Fachrichtung;

            public string Fragenart;

        //Methode zur Ausgabe der Frage
            public string ausgabe()
            {
                //Es wird ein Text mit Fragennummer, die aus der Variablen der
                //Form2 gezogen und um 1 erhöht wird (da es sich auch um einen
                //Index handelt), und dem Fragetext, der von der entsprechende Frage
                //aus der Datenbank kommt, zusammengesetzt
                return "Frage " + (PrüfungsSimulator.Form2.aktFragennr+1) + ": " + Fragetext;
            }

        //Konstruktoren
        public Frage()
            {
                FragenID = 0;
                Fragetext = "leer";
                Fachrichtung = "leer";
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
