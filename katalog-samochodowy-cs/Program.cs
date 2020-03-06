using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog_samochodowy_cs
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Pojazd nowyPojazd = new Pojazd("Opel","Vectra",2000,1.9f,2331,'A');
            Rejestr.lista.Add(nowyPojazd);
            nowyPojazd = new Pojazd("Nissan", "Navara", 2003, 1.3f, 242342, 'M');
            Rejestr.lista.Add(nowyPojazd);
            Rejestr.ZapiszZawartoscKataloguDoPliku();
            Rejestr.WczytajZawartoscKataloguZPliku();
            Rejestr.lista[0].Wypisz();
            Rejestr.lista[1].Wypisz();
            Console.ReadLine();
        }
    }


}
