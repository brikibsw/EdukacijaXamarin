using System;
using Basic.Klase;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            // namespace
            // klase
            // statičke klase
            // nasljedjivanje
            // konstruktori
            // propertiji
            // fieldovi
            // metode
            // extension metode
            // overloading metoda

            var pas = new Pas("Pero");
            Console.WriteLine(pas);

            var macka = new Macka();
            macka.Ime = "Mici";
            Console.WriteLine(macka);

            Console.ReadLine();
        }
    }
}
