// Služe za kategoriziranje klasa, te omogućuju da imamo klase sa istim 
// imenom u različitim namespace-ima.
// Za korištenje klasa iz drugoh namespace-a koristimo keyword(ključna riječ) *using*
// namespace možemo dodatno granati sa .
//  - Demo.Test : nemoze pristupati Demo.Test.Klase bez *using*
//  - Demo.Test.Klase : moze pristupati Demo.Test
// sintaksa
// keyword   naziv          blok koda
// namespace Naziv.Podnaziv { }

using System;

namespace Basic.Klase
{
    // klasa je korisničko definirani nacrt iz kojeg se stvaraju objekti.
    // Može sadržavati korisničko definirane property-e(svojstva) i metode.

    // sintaksa
    // accessor*  keyword   naziv          blok koda
    // public     class     NazivKlase     { }

    // accessor - označava dostupnost , private = samo članovi iz istog objekta
    //                                  public = članovi iz bilo kojeg objekta

    // klasa se instancira sa keyword-om *new* 
    // sintaksa instanciranja
    // new NazivKlase() : obratiti pozornost na zagrade na kraju
    // primjer
    // var instancaNekeKlase = new NazivKlase(1);
    // NazivKlase instancaNekeKlase = new NazivKlase();

    public class Osoba
    {
        // svaka klasa ima internu metodu koja se zove konstruktor i koja se izvršava
        // kada se klasa instancira. klasa može imati više od jednog korisničko definiranog konstruktora
        // a oni se moraju razlikovati po broju i tipu parametara.
        // sintaksa za konstruktor je 
        // public NazivKlase(parametri...) { }
        // konstruktor je poseban po tome što nema tip i naziv mu mora biti točno isti kao i naziv klase.

        public Osoba()
        {
        }

        public Osoba(int a)
        {
        }

        public Osoba(string a)
        {
        }

        /// <summary>
        /// Klasa osoba
        /// </summary>
        /// <param name="i">Ime osobe</param>
        /// <param name="p">Prezime osobe</param>
        public Osoba(string i, string p)
        {
            Ime = i;
            Prezime = p;
        }

        public static string Id = "1";

        // field
        // koristi se za spremanje i čitanje podataka, i uglavnom za privatne članove
        // sličan je varijabli 
        private string ime = "pero";

        // koristi se za spremanje i čitanje podataka, i uglavnom za javne(public) članove
        // kod propertija možemo modificirati default-nu logiku metode get i set
        // razlika izmedju field-a i property-a je u get set metodama, field nema 
        // get set metode koje možemo modificirati

        // primjer peroperty-a sa modificiranim get i set metodama
        public string Ime
        {
            get { return ime + ime; }
            set
            {
                ime = value + " ";
            }
        }

        // primjer auto-property-a
        public string Prezime { get; set; }

        // primjer peroperty-a sa modificiranim get i set metodama
        // te backing field-om
        private decimal cijena;
        public decimal Cijena
        {
            get => cijena;
            set
            {
                cijena = value;
                // metoda Formatiraj je extension metoda
                CijenaUKunama = cijena.Formatiraj();
            }
        }

        // primjer auto-property-a sa private set metodom koja dozvoljava 
        // postavljanje vrijednosti samo članovima iz iste klase
        public string CijenaUKunama { get; private set; }

        // primjer read-only property-a
        // property se moze koristiti samo za vracanje neke vrijednosti a ona moze 
        // biti kombinirana od više vrijednosti različitih propertya
        public string ImePrezime
        {
            get
            {
                return Ime + Prezime;
            }
        }

        // konvencija nazivanja property-a i metoda
        // public PascalCase

        // private camelCase



        // metoda je član klase
        // metoda obavlja određenu zadaću koja je definirana u bloku koda nakon pozivanja metode
        // metoda moze biti tipa void tada nevraća ništa ili nekog drugog tipa i tada mora vratiti
        // vrijednost tog tipa
        // metoda može primati parametre (0...x)

        // sintaxa deklaracije metode
        // accessor type    name (parameters...) { coode block }
        // public   string  Naziv(int param1, string param2 ....) 
        // {
        //      neka funkcionalnost
        // }

        // sintaxa pozivanja metode
        // kada je tip void -  ImeMetode(parametri...);
        // kada je neki tip -  var a = ImeMetode(parametri...);

        // primjeri overload-anja metoda
        public string Print(string x)
        {
            return x + Ime + Prezime + ImePrezime;
        }

        // metode mogu imati isti naziv i različit tip u istoj klasi ako imaju različite tipove i broj parametara
        public string Print(int x)
        {
            return x + Ime + Prezime + ImePrezime;
        }

        // kod overload-anja metoda najvažnije je broj i tip parametara da se razlikuje
        public int Print(int x, string y)
        {
            return x + y.Length + Ime.Length + Prezime.Length + ImePrezime.Length;
        }

        // metoda tipa void nevraća nikakvu vrijednost
        public void Print()
        {
            Console.WriteLine(ImePrezime);
        }

        // metoda tipa void nevraća nikakvu vrijednost
        public virtual void Test()
        {
            Console.WriteLine(CijenaUKunama);
        }
    }

    // nasljedjuju se svi public članovi ali ne i konstruktori
    public class Susjed : Osoba
    {
        // 
        public Susjed() : base("", "")
        {

        }

        // pošto se konstruktori nenasljedjuju, možemo pozvati konstruktor iz parent klase na sljedeći način
        //                                         *pozivanje konstruktora iz parent klase*
        public Susjed(string ime, string prezime) : base(ime, prezime)
        {

        }
    }


    // kada nestatička klasa sadrži statičke članove njima se može i mora 
    // pristupati na statički način, a to znači preko definicije klase
    // kada instanciramo nestatičku klasu preko te instance 
    // nemožemo pristupati statičkim članovima
    // sintaksa
    // NeStatickaKlasa.NekiProperty

    public class NeStatickaKlasa
    {
        public static string NekiStatickiProperty = "";

        public string NekiNestatickiProperty = "";

        public static int Zbroj(Osoba osoba)
        {
            return osoba.Ime.Length + osoba.Prezime.Length;
        }
    }

    // ako je klasa statička onda ju nemožemo instancirati i 
    // svi njeni članovi moraju biti statički
    // članovima pristupamo na statički način preko definicije klase
    // sintaksa
    // StatickaKlasa.NekiProperty

    public static class StatickaKlasa
    {
        public static string NekiProperty = "";

        public static string GetSetProperty { get; set; }

        private static string A = "";

        public static int NekaStatickaMetoda(int id = 1, int b = 1)
        {

            return id + b;
        }
    }

    // statičke klase i članovi se koriste za jednostavne i jednozadaćne funkcionalnosti (logika metode)
    // te kod Extension metoda


    // extension metode se moraju definirati u statickim klasama te i one same moraju biti staticke metode
    // specificnost je keyword *this* prije definiranja prvog parametra i može se koristiti samo za prvi parametar
    // te se taj parametar prosljedjuje automatski kod pozivanje te metode, 
    // svi ostali parametri koji su definirani se moraju prosljediti kao i za svaku drugu metodu

    public static class Ekstenzije
    {
        public static int Zbroj(this Osoba osoba)
        {
            return osoba.Ime.Length + osoba.Prezime.Length;
        }

        public static string Formatiraj(this decimal value, string format)
        {
            return value.ToString("#0,00") + " kn";
        }

        public static string Formatiraj(this decimal value)
        {
            return value.ToString("#0,00") + " kn";
        }

        public static string Formatiraj(this int value)
        {
            return value.ToString("#0,00") + " kn";
        }
    }
}

namespace Basic.DrugeKlase
{
    // Klase sa istim imenom mogu postojati u različitim namespace-ima
    public class Osoba
    {
        // field
        private string ime;

        // property
        public string Ime { get; set; }

        public string Prezime { get; set; }


        public string ImePrezime
        {
            get
            {
                return Ime + Prezime;
            }
        }

        // metoda
        public string Print(string x)
        {
            return x + Ime + Prezime + ImePrezime;
        }
    }
}