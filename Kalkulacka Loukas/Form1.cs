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
        public Form1()
        {
            InitializeComponent();
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
                // přidat další číslo
                txtDisplay.Text = txtDisplay.Text + ((Button)sender).Text;
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Seš mongoloid");
            }
        }

        private void btSmazat_Click(object sender, EventArgs e)
        {
            try
            {
                txtDisplay.Text = "0";
            }
            catch (Exception ex)
            { }
        }
    }
}
