using System;

namespace katalog_samochodowy_cs
{
    public class Pojazd
    {
		public string marka;
		public string model;
		public int rocznik;
		public float pojemnosc;
		public int przebieg;
		public char typSkrzyniBiegow;
		public Pojazd()
		{
			marka = "Marka";
			model = "Model";
			rocznik = 0000;
			pojemnosc = 0;
			przebieg = 0;
			typSkrzyniBiegow = 'B';
		}
		public Pojazd(string _marka, string _model, int _rocznik, float _pojemnosc, int _przebieg, char _typSkrzyniBiegow)
		{
			marka = _marka;
			model =_model;
			rocznik = _rocznik;
			pojemnosc = _pojemnosc;
			przebieg = _przebieg;
			typSkrzyniBiegow = _typSkrzyniBiegow;
		}
		public void Wypisz()
		{
			System.Console.WriteLine(String.Format("{0,-12} {1,-12} {2,-7} {3,-9} {4,-9} {5,-7}", marka, model, rocznik, pojemnosc, przebieg, typSkrzyniBiegow));
		}
	}
}