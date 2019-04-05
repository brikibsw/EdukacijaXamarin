using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Klase
{
    public class Zivotinja
    {
        public Zivotinja(string t)
        {
            Tip = t;
        }

        public string Ime { get; set; }

        public string Tip { get; }

        public override string ToString()
        {
            return Tip + "  " + Ime;
        }
    }

    public class Pas : Zivotinja
    {
        public Pas() : base("PAS")
        {
        }

        public Pas(string i) : base("PAS")
        {
            Ime = i;
        }
    }

    public class Macka : Zivotinja
    {
        public Macka() : base("MACKA")
        {

        }
    }

    public static class ZivotinjaExtensions
    {
        public static void Print(this Zivotinja zivotinja)
        {
            Console.WriteLine(zivotinja.Tip + "  " + zivotinja.Ime);
        }
    }
}
