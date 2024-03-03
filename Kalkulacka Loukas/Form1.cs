using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulacka_Loukas
{
    public partial class Form1 : Form
    {
        // typ prováděné operace
        enum enOperace { plus, minus, krat, deleno, clear, rovno }
        //stavové proměnné
        float mflCislo1, mflCislo2, mflVysledek;
        
        enOperace menAktOperace;
        public Form1()
        {
            InitializeComponent();
            //inicializace proměnných
            VseVymazat();
        }
       

        private void Kalkulacka_Load(object sender, EventArgs e)
        {

        }

        private void btCislo_Click(object sender, EventArgs e)
        {
            try 
            {
                // smazat úvodní nulu
                if (txtDisplay.Text == "0") txtDisplay.Text = "";
                //maže výsledek pokud hned zadáme číslo
                else if (menAktOperace == enOperace.rovno) txtDisplay.Text = "";
                //maže nulu po napsání nového čísla
                else if (Convert.ToSingle(txtDisplay.Text) == mflCislo1) txtDisplay.Text = "";
                // přidat další číslo
                txtDisplay.Text = txtDisplay.Text + ((Button)sender).Text;

            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Zkus to znovu");
            }
        }
        //
        //definování proměných za pomocí stisknutého tlačítka
        //
    

        private void btOperace_Click(object sender, EventArgs e)
        {
            Button lobjTlacitko;
            //tlacitko ktere zavolalo funci
            lobjTlacitko = (Button)sender;
            //vybrat operaci
            switch (lobjTlacitko.Text)
            {
                //vymazat vše
                case "C" : 
                    VseVymazat();
                    break;
                //sčítání
                case "+": 
                    mflCislo1=Convert.ToSingle(txtDisplay.Text);
                    menAktOperace = enOperace.plus;
                    break;
                //odčítání
                case "-":
                    mflCislo1 = Convert.ToSingle(txtDisplay.Text);
                    menAktOperace = enOperace.minus;
                    break;
                //dělení
                case "/":
                    mflCislo1 = Convert.ToSingle(txtDisplay.Text);
                    menAktOperace = enOperace.deleno;
                    break;
                //násobení
                case "*":
                    mflCislo1 = Convert.ToSingle(txtDisplay.Text);
                    menAktOperace = enOperace.krat;
                    break;
                case "=":
                    mflCislo2 = Convert.ToSingle(txtDisplay.Text);
                    // provedení finálního výpočtu po stisku =
          
                    if (menAktOperace == enOperace.plus) mflVysledek = mflCislo1 + mflCislo2;
                    else if (menAktOperace == enOperace.minus) mflVysledek = mflCislo1 - mflCislo2;
                    else if (menAktOperace == enOperace.deleno) mflVysledek = mflCislo1 / mflCislo2;
                    else if (menAktOperace == enOperace.krat) mflVysledek = mflCislo1 * mflCislo2;

                    menAktOperace = enOperace.rovno;
                    txtDisplay.Text = mflVysledek.ToString();
                    break;
            }
            
        }

                    //
                    // Uvedení kalkulačky do základního stavu
                    //
        private void VseVymazat()
        {
            //smazat úvodní nulu
            txtDisplay.Text = "0";
            //inicializace proměnných
            mflCislo1 = mflCislo2 = mflVysledek = 0;
            menAktOperace = enOperace.clear;
        }
    }
}
