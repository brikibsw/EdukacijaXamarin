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

            var djuro = new Osoba();
            djuro.Ime = "Djuro";
            djuro.Prezime = "Djuric";
            djuro.Starost = 66;

            var brojevi = new int[] { 1, 2, 3, 4, 5 };
            var stringovi = new string[] { "Neki", "Niz", "stringova" };

            for (int j = 0; j < 100; j++)
            {
                //Console.WriteLine(j);
            }

            int i = 100;
            while (i < 100)
            {
                Console.WriteLine(i);
                i++;
            }

            int ii = 100;
            do
            {
                Console.WriteLine(ii);
                ii++;
            } while (ii < 100);

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