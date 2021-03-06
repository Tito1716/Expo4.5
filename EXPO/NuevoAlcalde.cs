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
using System.Data.SqlClient;
using System.Data.Sql;

namespace EXPO
{
    public partial class NuevoAlcalde : Form
    {
        Validacion v = new Validacion();
        public NuevoAlcalde()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string urlfoto;
            if (pctFoto.Image != null)
            {
                urlfoto = "imagenes/" + txtNombre.Text + ".jpeg";
                pctFoto.Image.Save(urlfoto, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                urlfoto = "imagenes/no_disponible.png";
            }
            string guardar = "UPDATE Alcaldes SET Nombre" + txtNombre + "', Edad='" + txtEdad + "', Genero + '" + cmbGenero.SelectedValue + "',  Partido '" + cmbPartido.SelectedValue + "', Foto '" + urlfoto + "', Zona '" + cmbZona.SelectedValue + "' WHERE id_Alcalde=" + txtNombre.Text;
            EXPO.dbexpo.mthEjecutarOperacion(guardar);
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog();
            imagen.Title = "Seleccionar imagen";
            imagen.Filter = "Archivos de imagen (*.jpg, *.png, *.bmp, *.gif)|*.jpg; *.png; *.bmp; *.gif";
            if (imagen.ShowDialog() == DialogResult.OK)
            {
                pctFoto.ImageLocation = imagen.FileName;
            }
        }

        private void NuevoAlcalde_Load(object sender, EventArgs e)
        {
            string dato = "SELECT * FROM Genero";
            cmbGenero.DataSource = dbexpo.mthCargarDatos(dato);
            cmbGenero.ValueMember = "Id_genero";
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.SelectedIndex = -1;

            string dato1 = "SELECT * FROM Partidos";
            cmbPartido.DataSource = dbexpo.mthCargarDatos(dato1);
            cmbPartido.ValueMember = "id_Partido";
            cmbPartido.DisplayMember = "Partido";
            cmbPartido.SelectedIndex = -1;

            string dato2 = "SELECT * FROM ZonaDepto";
            cmbZona.DataSource = dbexpo.mthCargarDatos(dato2);
            cmbZona.ValueMember = "id_depto";
            cmbZona.DisplayMember = "Zona";
            cmbZona.SelectedIndex = -1;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRInicio f = new FRInicio();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
