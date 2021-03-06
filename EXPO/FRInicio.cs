using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXPO
{
    public partial class FRInicio : Form
    {
        public FRInicio()
        {
            InitializeComponent();
        }

        private void FRInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresarVot_Click(object sender, EventArgs e)
        {
            FRLoginVot frm = new FRLoginVot();
            frm.Show();
            this.Hide();
        }

        private void btnRegVot_Click(object sender, EventArgs e)
        {
            FRNuevoVotante frm = new FRNuevoVotante();
            frm.Show();
            this.Hide();
        }

        private void btnIngresarAdmin_Click(object sender, EventArgs e)
        {
            FRLogin frm = new FRLogin();
            frm.Show();
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
    }
}
