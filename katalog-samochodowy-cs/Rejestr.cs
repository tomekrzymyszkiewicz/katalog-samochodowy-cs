using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace katalog_samochodowy_cs
{
    class Rejestr
    {
        public static List<Pojazd> lista = new List<Pojazd>();
        static string nazwaPliku = "katalogcs.txt";
        public static void ZapiszZawartoscKataloguDoPliku()
        {
            FileStream plik = new FileStream(nazwaPliku, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter strumienZapisu = new StreamWriter(plik);
            for( int i = 0; i < Rejestr.lista.Count; i++)
            {
                strumienZapisu.WriteLine(Rejestr.lista[i].marka + " " + Rejestr.lista[i].model + " " + Rejestr.lista[i].pojemnosc + " " + Rejestr.lista[i].przebieg + " " + Rejestr.lista[i].rocznik + " " + Rejestr.lista[i].typSkrzyniBiegow);
            }
            strumienZapisu.Close();
        }
        public static void WczytajZawartoscKataloguZPliku()
        {

        }

    }
}
