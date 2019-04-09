using Generics.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var osoba = new Komsija();
            osoba.Id = 12;

            var osobaServis = new DemoServis<Komsija>();
            osobaServis.Pero(osoba);

            var dijete = new Dijete();
            dijete.Id = 144;

            var dijeteServis = new DemoServis<Dijete>();
            var broj = dijeteServis.Pero(dijete);

            Console.ReadLine();
        }
    }
}
