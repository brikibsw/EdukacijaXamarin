using System;
using System.Collections.Generic;

namespace DemoArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var brojevi = new List<int>();
            var operatori = new List<string>();

            var jednako = false;
            var tip = "operacija";

            while (jednako == false)
            {
                if (tip == "broj")
                {
                    var poruka = brojevi.Count < 2 ? "Unesite operaciju" : "Unesite operaciju ili znak = za rezultat";
                    var operacija = Operator(poruka, brojevi.Count >= 2);
                    if (operacija != "=")
                    {
                        operatori.Add(operacija);
                        tip = "operacija";
                    }
                    else
                    {
                        jednako = true;
                    }
                }
                else
                {
                    brojevi.Add(Broj("Unesite broj"));
                    tip = "broj";
                }
            }

            var rezultat = brojevi[0];
            var odgovor = brojevi[0].ToString();

            for (int i = 1; i < brojevi.Count; i++)
            {
                var broj2 = brojevi[i];
                var operacija = operatori[i - 1];
                rezultat = Rezultat(rezultat, broj2, operacija);
                odgovor = odgovor + " " + operacija + " " + broj2;
            }

            odgovor = odgovor + " = " + rezultat;

            Console.WriteLine(odgovor);
            Console.ReadLine();
        }

        public static int Rezultat(int x, int y, string o)
        {
            int rezultat = 0;

            switch (o)
            {
                case "+":
                    rezultat = Kalkulator.Zbroji( x, y );
                    break;
                case "-":
                    rezultat = Kalkulator.Oduzmi( x, y );
                    break;
                case "*":
                    rezultat = Kalkulator.Mnozi( x, y );
                    break;
                default:
                    rezultat = Kalkulator.Djeli( x, y );
                    break;
            }

            return rezultat;
        }

        public static string Operator(string poruka, bool jednako = false)
        {
            var input = "";

            if (jednako)
            {
                while (input != "+" && input != "-" && input != "/" && input != "*" && input != "=")
                {
                    Console.WriteLine(poruka);
                    input = Console.ReadLine();
                }
            }
            else
            {
                while (input != "+" && input != "-" && input != "/" && input != "*")
                {
                    Console.WriteLine(poruka);
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        public static int Broj(string poruka)
        {
            int broj = 0;
            bool uspio = false;
            string input = null;

            while (uspio == false)
            {
                Console.WriteLine(poruka);
                input = Console.ReadLine();
                uspio = int.TryParse(input, out broj);
            }

            return broj;
        }
    }
}