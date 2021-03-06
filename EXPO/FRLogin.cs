using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using DevLib.ModernUI.ComponentModel;
using DevLib.ModernUI.Drawing;

namespace EXPO
{
    public partial class FRLogin : Form
    {
        Validacion v = new Validacion();
        public FRLogin()
        {
            InitializeComponent();
        }
        public FRLogin(string variable)
        {
            this.variable = variable;
        }
        string key = "llave";
        private readonly string variable;

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void FRLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRInicio F = new FRInicio();
            F.Show();
            this.Hide();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtContra.Text.Trim() != "" && txtUsuario.Text.Trim() != "")
            {
                string consultar = "SELECT Usuario FROM Login WHERE Usuario = '" + txtUsuario.Text + "' AND Clave =" + txtContra.Text;
                EXPO.dbexpo.mthLogin(consultar);
                string contar = "SELECT Usuario FROM Login WHERE Usuario ='" + txtUsuario.Text + "' AND Clave =" + txtContra.Text;
                string variable = Convert.ToString(EXPO.dbexpo.mthObtenerValor(contar));
                if (variable != "")
                {
                    MessageBox.Show("Bienvenido " + txtUsuario.Text,
                    "¡Inicio de sesión exitoso!");
                    mthLimpiar();
                    FRRedireccion form2 = new FRRedireccion();
                    form2.Show();
                    this.Hide();
                }
            }
        }

        void mthLimpiar()
        {
            txtUsuario.Clear();
            txtContra.Clear();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtContra_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}