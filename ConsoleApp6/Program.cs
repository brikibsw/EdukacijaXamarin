using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            var pero = new Osoba();
            pero.Ime = "Pero";
            pero.Prezime = "Perić";
            pero.Starost = 55;

            Ispis(pero);

            var djuro = new Osoba();
            djuro.Ime = "Djuro";
            djuro.Prezime = "Djuric";
            djuro.Starost = 66;

            Ispis(djuro);

            IspisSaToString(djuro);

            Console.ReadLine();
        }

        static void Ispis(Osoba osoba)
        {
            var str = osoba.Prezime + ", " + osoba.Ime + " " + osoba.Starost;
            Console.WriteLine(str);
        }

        static void IspisSaPropertijem(Osoba osoba)
        {
            var str = osoba.PrezimeIme + " " + osoba.Starost;
            Console.WriteLine(str);
        }

        static void IspisSaToString(Osoba osoba)
        {
            Console.WriteLine(osoba.ToString());
        }
    }
}