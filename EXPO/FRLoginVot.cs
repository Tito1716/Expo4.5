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
    public partial class FRLoginVot : Form
    {
        Validacion v = new Validacion();
        public FRLoginVot()
        {
            InitializeComponent();
        }
    private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtContra.Text.Trim() != "" && txtUsuario.Text.Trim() != "")
            {
                string consultar = "SELECT Carnet FROM Votantes WHERE Carnet = " + txtUsuario.Text + " AND Contraseña =" + txtContra.Text;
                EXPO.dbexpo.mthLogin(consultar);
                string contar = "SELECT Carnet FROM Votantes WHERE Carnet =" + txtUsuario.Text + " AND Contraseña =" + txtContra.Text;
                string variable = Convert.ToString(EXPO.dbexpo.mthObtenerValor(contar));
                if (variable != "")
                {
                    string carnet = txtUsuario.Text;
                    mthLimpiar();
                    FRMenuVotante f = new FRMenuVotante(carnet);
                    f.Show();
                    this.Hide();
                }
            }
        }
        void mthLimpiar()
        {
            txtUsuario.Clear();
            txtContra.Clear();
        }

        private void modernCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRInicio F = new FRInicio();
            F.Show();
            this.Hide();
        }

        private void linkRecuperar_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void cBxMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtContra.Text;
            if (cBxMostrarContra.Checked)
            {
                txtContra.UseSystemPasswordChar = false;
                txtContra.Text = text;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
                txtContra.Text = text;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRRecuperarContraseña f = new FRRecuperarContraseña();
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

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRInicio fr = new FRInicio();
            fr.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtContra_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
