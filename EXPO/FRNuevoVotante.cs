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
    public partial class FRNuevoVotante : Form
    {
        Validacion v = new Validacion();
        public FRNuevoVotante()
        {
            InitializeComponent();
        }

        private void FRNuevoVotante_Load(object sender, EventArgs e)
        {
            string dato = "SELECT * FROM Genero ";
            cmbGenero.DataSource = dbexpo.mthCargarDatos(dato);
            cmbGenero.ValueMember = "Id_genero";
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.SelectedIndex = -1;

            string dato1 = "SELECT * FROM Preguntas";
            cmbPregunta.DataSource = dbexpo.mthCargarDatos(dato1);
            cmbPregunta.ValueMember = "Id_pregunta";
            cmbPregunta.DisplayMember = "Pregunta";
            cmbPregunta.SelectedIndex = -1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtCarnet.Text.Trim() != "" && txtNombre.Text.Trim() != "")
            {
                string carnet, nombre, apellidos, edad, genero, contraseña, pregunta, respuesta;
                carnet = txtCarnet.Text;
                nombre = txtNombre.Text;
                contraseña = txtContra.Text;
                edad = txtEdad.Text;
                apellidos = txtApellido.Text;
                pregunta = cmbPregunta.SelectedText;
                genero = cmbGenero.SelectedText;
                respuesta = txtRespuesta.Text;
                string insertar = "INSERT INTO Votantes (Carnet, Nombres, Apellidos, Edad, Genero, Contraseña, Pregunta_seguridad, Respuesta, Correo_Electronico) VALUES (" + carnet + ", '" + nombre + "', '" + apellidos + "','" + edad + "'," + cmbGenero.SelectedValue + "," + contraseña + ", " + cmbPregunta.SelectedValue + ",'" + txtRespuesta + "', '" + txtCorreo.Text + "')";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);
                mthLimpiar();
            }
        }
        void mthLimpiar()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
            txtContra.Clear();
            txtEdad.Clear();
            txtApellido.Clear();
            txtRespuesta.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbPregunta.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRInicio f = new FRInicio();
            f.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtCarnet_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtApellido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtEdad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void modernComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
