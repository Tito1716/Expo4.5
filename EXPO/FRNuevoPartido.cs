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

namespace EXPO
{
    public partial class FRNuevoPartido : Form
    {
        Validacion v = new Validacion();
        public FRNuevoPartido()
        {
            InitializeComponent();
        }

        private void FRNuevoPartido_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string url;
            if (pictureBox1.Image != null)
            {
                url = "imagenes/" + txtNombre.Text + ".png";
                pictureBox1.Image.Save(url, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                url = "imagenes/no_disponible.png";
            }
            string guardar = "UPDATE Partido SET Nombre='" + txtNombre.Text + "', Imagen='" + url + "' WHERE Id_Partido=" + txtNombre.Text;
            MessageBox.Show(guardar);
            EXPO.dbexpo.mthEjecutarOperacion(guardar);
        }
        void mthLimpiar()
        {
            txtNombre.Clear();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
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

        private void btnAtras_Click(object sender, EventArgs e)
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

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }
    }
}
