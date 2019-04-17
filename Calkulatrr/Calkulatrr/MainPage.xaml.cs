using System;
using Xamarin.Forms;

namespace Calkulatrr
{
    public partial class MainPage : ContentPage
    {
        private decimal? _prviBroj = null;
        private decimal? PrviBroj
        {
            get { return _prviBroj; }
            set
            {
                _prviBroj = value;
                SetRezultatText();
            }
        }

        private string _operacija = null;
        private string Operacija // + - * /
        {
            get { return _operacija; }
            set
            {
                _operacija = value;
                SetRezultatText();
            }
        }

        private decimal? _drugiBroj = null;
        private decimal? DrugiBroj
        {
            get { return _drugiBroj; }
            set
            {
                _drugiBroj = value;
                SetRezultatText();
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void SetRezultatText()
        {
            var p1 = PrviBroj != null ? PrviBroj.ToString() + (commaPressed && PrviBroj.ToString().Contains(".") == false ? "," : "") : "";
            var p2 = Operacija != null ? Operacija : "";
            var p3 = DrugiBroj != null ? DrugiBroj.ToString() + (commaPressed && !DrugiBroj.ToString().Contains(".") ? "," : "") : "";
            Rezultat.Text = $"{p1.Replace(".", ",")} {p2} {p3.Replace(".", ",")}";
        }

        private void CE_Button_Clicked(object sender, EventArgs e)
        {
            if( Operacija == null )
            {
                PrviBroj = null;
            }
            else
            {
                DrugiBroj = null;
            }
        }

        private void C_Button_Clicked(object sender, EventArgs e)
        {
            PrviBroj = null;
            Operacija = null;
            DrugiBroj = null;
            Formula.Text = "";
        }

        private void BKSP_Button_Clicked(object sender, EventArgs e)
        {
            if ( Operacija == null )
            {
                if( PrviBroj != null )
                {
                    Backspace(broj: PrviBroj, daliJePrviBrojUPitanju: true);
                }
            }
            else
            {
                if( DrugiBroj == null )
                {
                    Operacija = null;
                }
                else
                {
                    Backspace(DrugiBroj, false);
                }
            }
        }

        private void Backspace(decimal? broj, bool daliJePrviBrojUPitanju)
        {
            var brojString = broj.ToString();
            brojString = brojString + (commaPressed && broj.ToString().Contains(".") == false ? "," : "");
            var brojSubstring = brojString.Substring(0, brojString.Length - 1);

            if (commaPressed)
            {
                commaPressed = false;
            }

            if (brojString.Length > 2)
            {
                commaPressed = brojString.Substring(brojString.Length - 2, 1) == ".";
            }

            if (brojSubstring != "" && brojSubstring != "-")
            {
                broj = decimal.Parse(brojSubstring);
            }
            else
            {
                broj = null;
            }

            if( daliJePrviBrojUPitanju == true )
            {
                PrviBroj = broj;
            }
            else
            {
                DrugiBroj = broj;
            }
        }

        private void DVD_Button_Clicked(object sender, EventArgs e)
        {
            SetOperator("/");
        }

        private void NUM7_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(7);
        }

        private void NUM8_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(8);
        }

        private void NUM9_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(9);
        }

        private void MLTP_Button_Clicked(object sender, EventArgs e)
        {
            SetOperator("*");
        }

        private void NUM4_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(4);
        }

        private void NUM5_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(5);
        }

        private void NUM6_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(6);
        }

        private void SUB_Button_Clicked(object sender, EventArgs e)
        {
            SetOperator("-");
        }

        private void NUM1_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(1);
        }

        private void NUM2_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(2);
        }

        private void NUM3_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(3);
        }

        private void ADD_Button_Clicked(object sender, EventArgs e)
        {
            SetOperator("+");
        }

        private void PM_Button_Clicked(object sender, EventArgs e)
        {
            if( DrugiBroj == null )
            {
                PrviBroj = PrviBroj * -1;
            }
            else
            {
                DrugiBroj = DrugiBroj * -1;
            }
        }

        private void NUM0_Button_Clicked(object sender, EventArgs e)
        {
            SetNumbers(0);
        }

        private bool commaPressed = false;

        private void COM_Button_Clicked(object sender, EventArgs e)
        {
            if( Operacija == null )
            {
                if( commaPressed == false && PrviBroj.ToString().Contains(".") == false )
                {
                    commaPressed = true;

                    if(PrviBroj == null)
                    {
                        PrviBroj = 0;
                    }
                }
            }
            else
            {
                if (commaPressed == false && DrugiBroj.ToString().Contains(".") == false)
                {
                    commaPressed = true;

                    if (DrugiBroj == null)
                    {
                        DrugiBroj = 0;
                    }
                }
            }

            SetRezultatText();
        }

        private void EQ_Button_Clicked(object sender, EventArgs e)
        {
            Calculate();
        }

        private void SetNumbers(decimal broj)
        {
            if( Operacija == null )
            {
                if( PrviBroj == null )
                {
                    PrviBroj = broj;
                }
                else
                {
                    var tempBroj = PrviBroj.ToString() + (commaPressed ? "." : "") + broj;
                    PrviBroj = decimal.Parse(tempBroj);
                }
            }
            else
            {
                if (DrugiBroj == null)
                {
                    DrugiBroj = broj;
                }
                else
                {
                    var tempBroj = DrugiBroj.ToString() + (commaPressed ? "." : "") + broj;
                    DrugiBroj = decimal.Parse(tempBroj);
                }
            }

            if(commaPressed)
            {
                commaPressed = false;
            }
        }

        private void SetOperator(string o)
        {
            Calculate(o);
            Operacija = o;
        }

        private void Calculate(string o = null)
        {
            if( PrviBroj != null && Operacija != null && DrugiBroj != null )
            {
                if(Operacija == "/" && DrugiBroj == 0)
                {
                    // TODO: hendlati situaciju kada se dijeli sa 0
                }
                else
                {
                    decimal? rez = 0;
                    switch (Operacija)
                    {
                        case "+":
                            rez = PrviBroj + DrugiBroj;
                            break;
                        case "-":
                            rez = PrviBroj - DrugiBroj;
                            break;
                        case "*":
                            rez = PrviBroj * DrugiBroj;
                            break;
                        default:
                            rez = PrviBroj / DrugiBroj;
                            break;
                    }

                    Formula.Text = PrviBroj.ToString().Replace(".", ",") + " " + Operacija + " " + DrugiBroj.ToString().Replace(".", ",");

                    PrviBroj = rez;
                    Operacija = o;
                    DrugiBroj = null;
                }
            }
        }

    }
}
