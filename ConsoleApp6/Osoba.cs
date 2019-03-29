﻿namespace ConsoleApp6
{
    class Osoba
    {
        public Osoba() { }
        public Osoba(string i, string p, int s = 0)
        {
            Ime = i;
            Prezime = p;
            Starost = s;
        }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int Starost { get; set; }

        public string PrezimeIme
        {
            get
            {
                return Prezime + ", " + Ime;
            }
        }

        public override string ToString()
        {
            return PrezimeIme + " " + Starost;
        }
    }
}
