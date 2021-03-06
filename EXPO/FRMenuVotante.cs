using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using DevLib.ModernUI.ComponentModel;
using DevLib.ModernUI.Drawing;

namespace EXPO
{
    public partial class FRMenuVotante : Form
    {
        string carnet;
        public FRMenuVotante(string car)
        {
            InitializeComponent();
            carnet = car;
        }

        private void FRMenuVotante_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FREleccionDeVotacion f = new FREleccionDeVotacion(carnet);
            f.Show();
            this.Hide();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRLoginVot f = new FRLoginVot();
            f.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRPerfil f = new FRPerfil(carnet);
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRGraficoVotaciones f = new FRGraficoVotaciones(carnet);
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
