using System;
using Xamarin.Forms;

namespace Calkulatrr
{
    public partial class MainPage : ContentPage
    {
        private int? _prviBroj = null;
        private int? PrviBroj
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

        private int? _drugiBroj = null;
        private int? DrugiBroj
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
            var p1 = PrviBroj != null ? PrviBroj.ToString() : "";
            var p2 = Operacija != null ? Operacija : "";
            var p3 = DrugiBroj != null ? DrugiBroj.ToString() : "";
            Rezultat.Text = $"{p1} {p2} {p3}";
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
        }

        private void BKSP_Button_Clicked(object sender, EventArgs e)
        {
            if ( Operacija == null )
            {
                if( PrviBroj != null )
                {
                    var prviBrojString = PrviBroj.ToString();
                    var prviBrojSubstring = prviBrojString.Substring(0, prviBrojString.Length - 1);
                    if ( prviBrojSubstring != "" && prviBrojSubstring != "-" )
                    {
                        PrviBroj = int.Parse(prviBrojSubstring);
                    }
                    else
                    {
                        PrviBroj = null;
                    }
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
                    var drugiBrojString = DrugiBroj.ToString();
                    var drugiBrojSubstring = drugiBrojString.Substring(0, drugiBrojString.Length - 1);
                    if ( drugiBrojSubstring != "" && drugiBrojSubstring != "-" )
                    {
                        DrugiBroj = int.Parse(drugiBrojSubstring);
                    }
                    else
                    {
                        DrugiBroj = null;
                    }
                }
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

        private void COM_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void EQ_Button_Clicked(object sender, EventArgs e)
        {
            Calculate();
        }

        private void SetNumbers(int broj)
        {
            if( Operacija == null )
            {
                if( PrviBroj == null )
                {
                    PrviBroj = broj;
                }
                else
                {
                    var tempBroj = PrviBroj.ToString() + broj;
                    PrviBroj = int.Parse(tempBroj);
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
                    var tempBroj = DrugiBroj.ToString() + broj;
                    DrugiBroj = int.Parse(tempBroj);
                }
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
                    int? rez = 0;
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

                    Formula.Text = PrviBroj + " " + Operacija + " " + DrugiBroj;

                    PrviBroj = rez;
                    Operacija = o;
                    DrugiBroj = null;
                }
            }
        }

    }
}
