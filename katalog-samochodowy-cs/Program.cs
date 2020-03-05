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
            Rejestr.lista[0].Wypisz();
            Rejestr.ZapiszZawartoscKataloguDoPliku();
        }
    }


}
