using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = new DateTime(2019, 1, 1);
            var endDate = DateTime.Now;

            var diff = endDate - startDate;
            var rnd = new Random();
            var lista = new List<Rashod>();

            for (int i = 0; i < diff.TotalDays; i++)
            {
                var r = new Rashod
                {
                    Tip = i % 2 == 0 ? 1 : 2,
                    Naziv = " i " + i,
                    Vrijednost = rnd.Next(25, 550),
                    Datum = startDate.AddDays(i)
                };

                lista.Add(r);
            }

            // mjesec - tip 

            var gr = lista.GroupBy(a => a.Datum.Month).Select(a => new Mjesec
            {
                Month = a.Key,
                TipTroskas = a.GroupBy(b => b.Tip).Select(b => new TipTroska
                {
                    Tip = b.Key,
                    Rashodi = b.ToList()
                }).ToList()
            }).ToList();


            foreach (var item in gr)
            {
                Console.WriteLine($"Mjesec {item.Month}.");
                foreach (var tip in item.TipTroskas)
                {
                    Console.WriteLine($"     {tip.TipName} - {tip.Suma}");
                }
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Saldo: {item.SumaPrihoda - item.SumaRashoda}");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class Mjesec
    {
        public int Month { get; set; }

        public List<TipTroska> TipTroskas { get; set; }

        public decimal Suma { get => TipTroskas.Sum(a => a.Suma); }

        public decimal SumaPrihoda { get => TipTroskas.Where(a => a.Tip == 2).Sum(a => a.Suma); }

        public decimal SumaRashoda { get => TipTroskas.Where(a => a.Tip == 1).Sum(a => a.Suma); }
    }

    public class TipTroska
    {
        public int Tip { get; set; }

        public string TipName { get => Tip == 1 ? "Rashod" : "Prihod"; }

        public List<Rashod> Rashodi { get; set; }

        public decimal Suma { get => Rashodi.Sum(a => a.Vrijednost); }
    }

    public class Rashod
    {
        // rashod = 1 , prihod = 2
        public int Tip { get; set; }

        public string Naziv { get; set; }

        public decimal Vrijednost { get; set; }

        public DateTime Datum { get; set; }
    }




























    public class Troskovi
    {
        public List<Trosak> SviTroskovi { get; set; }

        public int Suma { get => SviTroskovi.Sum(a => a.Vrijednost); }
    }

    public class Trosak
    {
        public int Vrijednost { get; set; }
    }
}
