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
using DevLib.ModernUI.ComponentModel;
using DevLib.ModernUI.Drawing;

namespace EXPO
{
    public partial class FRNuevoUsuario : Form
    {
        Validacion v = new Validacion();
        public FRNuevoUsuario()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.loginTableAdapter.Fill(this.dBEXPODataSet.Login);
            string dato = "SELECT * FROM Genero ";
            cmbGenero.DataSource = dbexpo.mthCargarDatos(dato);
            cmbGenero.ValueMember = "Id_genero";
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.SelectedIndex = -1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
        void mthLimpiar()
        {
            txtNombre.Clear();
            txtClave.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "" && txtClave.Text.Trim() != "")
            {
                string usuario, clave, telefono, genero, edad;
                usuario = txtNombre.Text;
                clave = txtClave.Text;
                edad = txtEdad.Text;
                telefono = txtTelefono.Text;

                string insertar = "INSERT INTO Login (Usuario, Clave, Telefono, Genero, Edad) VALUES ('" + usuario + "', " + clave + ", " + telefono + ",'" + cmbGenero.SelectedValue + "'," + edad + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);
                mthLimpiar();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
      
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click_2(object sender, EventArgs e)
        {
            FRRedireccion F = new FRRedireccion();
            F.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }
    }
}
