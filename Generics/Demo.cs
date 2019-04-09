
using System;

namespace Generics.Demo
{
    // interface ima samo definicije objekta
    // svaka klasa koja implementira ovaj interface mora imati
    // property tipa int naziva Id i metodu tipa void naziva Print
    public interface IBasic
    {
        // članovi interface-a su public i nemozemo im staviti
        // accessor
        int Id { get; set; }

        // metrode u interface-u nemaju blok koda i završavaju sa ;
        // nemaju blok koda zato sto nemaju logiku nego se logika nalazi u 
        // klasu koja implemetira interface i metodu
        void Print();
    }

    // abstraktne klase se nemogu instancirati i uglavnom
    // se koriste za nasljedjivanje 
    public abstract class Basic : IBasic
    {
        public int Id { get; set; }

        public void Print()
        {
            Console.WriteLine(Id);
        }
    }

    // u ovom slucaju klasa Osoba nasljedjuje klasu Basic
    // i nasljedjuje član Id i član Print
    public class Osoba : Basic
    {
        public string Name { get; set; }
    }

    public class Komsija : Osoba
    {
        public int Kbr { get; set; }
    }

    // klasa koja implementira neki interface mora implementirati
    // sve članove iz interface-a
    public class Roditelj : IBasic
    {
        public int Id { get; set; }

        public void Print()
        {
            Console.WriteLine("Roditelj: " + Id);
        }
    }

    public class Dijete : IBasic
    {
        public int Id { get; set; }

        public void Print()
        {
            Console.WriteLine("Dijete: " + Id);
        }
    }
}
