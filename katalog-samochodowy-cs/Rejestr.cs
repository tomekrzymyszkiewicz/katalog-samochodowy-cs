using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
            plik.Close();
            Rejestr.lista.RemoveRange(0,Rejestr.lista.Count());
            Console.WriteLine("Zapisano!\nNaciśnij klawisz, aby kontynuować");
            Console.ReadLine();
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
                    Pojazd nowyPojazd = new Pojazd(dane[0], dane[1], int.Parse(dane[2]), float.Parse(dane[3]), int.Parse(dane[4]), char.Parse(dane[5]));
                    Rejestr.lista.Add(nowyPojazd);
                }
                strumienOdczytu.Close();
                plik.Close();
                Console.WriteLine("Wczytano!\nNaciśnij klawisz, aby kontynuować");
            }
            else
            {
                Console.WriteLine("Błąd! Nie istnieje plik z zawartością katalogu\nNaciśnij klawisz, aby kontynuować");
            }
            Console.ReadLine();
        }
        public static void DodajSamochodDoRejestru()
        {
            Console.Clear();
            Console.WriteLine("DODAWANIE NOWEGO SAMOCHODU DO REJESTRU");
            string[] dane = new string[6];
            Console.WriteLine("Marka: ");
            dane[0] = Console.ReadLine();
            Console.WriteLine("Model: ");
            dane[1] = Console.ReadLine();
            Console.WriteLine("Rocznik: ");
            dane[2] = Console.ReadLine();
            Console.WriteLine("Pojemność: ");
            dane[3] = Console.ReadLine();
            if (dane[3].Contains('.'))
                dane[3] = dane[3].Replace('.', ',');
            Console.WriteLine("Przebieg: ");
            dane[4] = Console.ReadLine();
            Console.WriteLine("Typ skrzyni biegów (A/M): ");
            dane[5] = Console.ReadLine();
            Pojazd nowyPojazd = new Pojazd(dane[0], dane[1], int.Parse(dane[2]), float.Parse(dane[3]), int.Parse(dane[4]), char.Parse(dane[5]));
            Rejestr.lista.Add(nowyPojazd);
            //Rejestr.lista.Add(new Pojazd(dane[0], dane[1], int.Parse(dane[2]), float.Parse(dane[3]), int.Parse(dane[4]), char.Parse(dane[5])));
            Console.WriteLine("Dodano samochód do rejestru!\nNaciśnij klawisz, aby kontynuować");
            Console.ReadLine();
        }
        public static void WypiszRejestr()
        {
            Console.Clear();
            Console.WriteLine("lp  Marka        Model        Rocznik Pojemnosc Przebieg  Skrzynia ");
            for (int i = 0; i < Rejestr.lista.Count(); i++)
            {
                Console.Write("{0,-4}",i+1);
                Rejestr.lista[i].Wypisz();
            }
        }
        public static void UsunSamochodZRejestru()
        {
            int doUsuniecia;
            do
            {
                Rejestr.WypiszRejestr();
                Console.WriteLine("Podaj numer samochodu do usunięcia: ");
                doUsuniecia = Convert.ToInt32(Console.ReadLine());
                Rejestr.lista.RemoveAt(doUsuniecia-1);
                if(doUsuniecia > 0 && doUsuniecia < Rejestr.lista.Count())
                {
                    Console.WriteLine("Wybrano numer z poza zakresu\nNaciśnij klawisz, aby kontynuować");
                    Console.ReadLine();
                }
            } while (doUsuniecia > 0 && doUsuniecia < Rejestr.lista.Count());
            Console.WriteLine("Usunięto pojazd numer {0}\nNaciśnij klawisz, aby kontynuować", doUsuniecia);
            Console.ReadLine();
        }
    }
}
