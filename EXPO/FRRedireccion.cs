using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevLib.ModernUI.ComponentModel;
using DevLib.ModernUI.Drawing;


namespace EXPO
{
    public partial class FRRedireccion : Form
    {
        string rut;
        public FRRedireccion()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void FRRedireccion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FRCandidatos f = new FRCandidatos();
            f.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FRPartidos f = new FRPartidos();
            f.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FRVotantes f = new FRVotantes();
            f.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FRNuevoUsuario f = new FRNuevoUsuario();
            f.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FRLogin f = new FRLogin();
            f.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FRNuevoPartido f = new FRNuevoPartido();
            f.Show();
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRInicio f = new FRInicio();
            f.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            NuevoAlcalde f = new NuevoAlcalde();
            f.Show();
            this.Hide();
        }
    }
}
