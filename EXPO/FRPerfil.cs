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
    public partial class FRPerfil : Form
    {
        Validacion v = new Validacion();
        string carnet;
        public FRPerfil(string c)
        {
            InitializeComponent();
            btnGuardar.Visible = false;
            btnImagen.Enabled = false;
            carnet = c;
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FRPerfil_Load(object sender, EventArgs e)
        {
            
        }

        private void FRPerfil_Load_1(object sender, EventArgs e)
        {
            string dato = "SELECT * FROM Genero ";
            cmbGenero.DataSource = dbexpo.mthCargarDatos(dato);
            cmbGenero.ValueMember = "Id_genero";
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRMenuVotante f = new FRMenuVotante(carnet);
            f.Show();
            this.Hide();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            btnImagen.Enabled = true;
            txtNombre.Enabled = true;
            txtEdad.Enabled = true;
            cmbGenero.Enabled = true;
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtEdad.Enabled = false;
            cmbGenero.Enabled = false;
            btnGuardar.Visible = false;
            btnModificar.Visible = true;
            btnImagen.Enabled = false;
            string modificar = "UPDATE Votantes SET Votante ='" + txtNombre.Text + "', Edad =" + txtEdad.Text + " WHERE Id_Genero =" + cmbGenero.SelectedItem;
        }

        private void btnImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            imagen.Title = "Seleccionar imagen";
            imagen.Filter = "Archivos de imagen (*.jpg, *.png, *.bmp, *.gif)|*.jpg; *.png; *.bmp; *.gif";
            if (imagen.ShowDialog() == DialogResult.OK)
            {
                //Se muestra la imagen seleccionada en el PictureBox.
                pictureBox1.ImageLocation = imagen.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
