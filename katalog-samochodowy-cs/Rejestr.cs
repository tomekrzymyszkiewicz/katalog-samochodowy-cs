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
            //FileStream plik = new FileStream(nazwaPliku, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream plik = new FileStream(nazwaPliku, FileMode.Append, FileAccess.Write);

            StreamWriter strumienZapisu = new StreamWriter(plik);
            plik.Seek(0, SeekOrigin.End);
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
                for(int i = 0; i < odczyt.Length-1; i++)
                {
                    string[] dane = odczyt[i].Split(' ','\r');
                    if (dane[3].Contains('.'))
                        dane[3] = dane[3].Replace('.', ',');
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
        public static void SortowanieRejestru()
        {
            bool posortowano = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Według którego parametru chcesz posortować rejestr: ");
                Console.WriteLine("1. Marka");
                Console.WriteLine("2. Model");
                Console.WriteLine("3. Rocznik");
                Console.WriteLine("4. Pojemność");
                Console.WriteLine("5. Przebieg");
                Console.WriteLine("6. Typ skrzyni biegów");
                Console.WriteLine("ESC. Wróć");
                //Pojazd p = new Pojazd();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.marka).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.model).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.rocznik).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.pojemnosc).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D5:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.przebieg).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D6:
                        Rejestr.lista = Rejestr.lista.OrderBy(p => p.typSkrzyniBiegow).ToList();
                        posortowano = true;
                        Console.WriteLine("Posortowano!\nNaciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.Escape:
                        posortowano = true;
                        break;
                    default:
                        break;
                }
            } while (!posortowano);
        }

    }
}
