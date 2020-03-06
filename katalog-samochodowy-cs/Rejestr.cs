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
            FileStream plik = new FileStream(nazwaPliku, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter strumienZapisu = new StreamWriter(plik);
            for( int i = 0; i < Rejestr.lista.Count; i++)
            {
                strumienZapisu.WriteLine(Rejestr.lista[i].marka + " " + Rejestr.lista[i].model + " "  + Rejestr.lista[i].przebieg + " " + Rejestr.lista[i].pojemnosc + " " + Rejestr.lista[i].rocznik + " " + Rejestr.lista[i].typSkrzyniBiegow);
            }
            strumienZapisu.Close();
        }
        public static void WczytajZawartoscKataloguZPliku()
        {
            if(File.Exists(nazwaPliku))
            {
                FileStream plik = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read);
                StreamReader strumienOdczytu = new StreamReader(nazwaPliku);
                string[] odczyt = strumienOdczytu.ReadToEnd().ToString().Split('\n');
                //string[] odczyt = strumienOdczytu.ToString().Split('\n');
                for(int i = 0; i < odczyt.Length-1; i++)
                {
                    string[] dane = odczyt[i].Split(' ','\r');
                    //string __marka = dane[0];
                    //string __model = dane[1];
                    //int __rocznik = Convert.ToInt32(dane[2]);
                    //float __pojemnosc = float.Parse(dane[3]);
                    //int __przebieg = int.Parse(dane[4]);
                    //char __typSkrzyniBiegow = Convert.ToChar(dane[5]);
                    Pojazd nowyPojazd = new Pojazd(dane[0], dane[1], int.Parse(dane[2]), float.Parse(dane[3]), int.Parse(dane[4]), char.Parse(dane[5]));
                    //Pojazd nowyPojazd = new Pojazd(__marka, __model, __rocznik, __pojemnosc, __przebieg, __typSkrzyniBiegow);
                    Rejestr.lista.Add(nowyPojazd);
                }
            }
            else
            {
                Console.WriteLine("Błąd! Nie istnieje plik z zawartością katalogu");
            }
            
        }

    }
}
