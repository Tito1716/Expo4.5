using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using DevLib.ModernUI.ComponentModel;
using DevLib.ModernUI.Drawing;

namespace EXPO
{
    public partial class FRPartidos : Form
    {
        public FRPartidos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPartido.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCandi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btnGuardar.Visible = false;
            btnModificar.Visible = true;
            btnEliminar.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FRPartidos_Load(object sender, EventArgs e)
        {
            mthMostrarDatos();

            string seleccionar = "SELECT * FROM Partidos";
            comboBox1.DataSource = dbexpo.mthCargarDatos(seleccionar);
            comboBox1.ValueMember = "id_Partido";
            comboBox1.DisplayMember = "Partido";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            btnGuardar.Visible = false;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
        }
        void mthMostrarDatos()
        {
            mthLimpiarCampos();
            string selecionar = "SELECT id_Partido, Partido, Num_Candidatos, Imagen FROM Partidos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label4.Text;
            dataGridView1.Columns[1].HeaderText = label3.Text;
            dataGridView1.Columns[2].HeaderText = label1.Text;
            dataGridView1.Columns[3].Visible = false;

        }
        void mthLimpiarCampos()
        {
            txtPartido.Clear();
            txtCandi.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtPartido.Text != "")
            {
                string eliminar = "DELETE FROM Partidos WHERE Partido = " + txtPartido.Text;
                dbexpo.mthEjecutarOperacion(eliminar);
                mthMostrarDatos();
                btnGuardar.Visible = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            if (txtPartido.Text.Trim() != "")
            {
                string url;
                if (pictureBox1.Image != null)
                {
                    url = "imagenes/" + txtPartido.Text + ".png";
                    pictureBox1.Image.Save(url, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    url = "imagenes/no_disponible.png";
                }
                string modificar = "UPDATE Partidos SET Partido='" + txtPartido.Text + "', Imagen='" + url + "', Num_Candidatos=" + txtCandi.Text + ", WHERE id_Partido=" + textBox1.Text;
                EXPO.dbexpo.mthEjecutarOperacion(modificar);
            }
            btnGuardar.Visible = true;
            btnEliminar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCandi.Text.Trim() != "")
            {
                string insertar = "INSERT INTO Partidos (Partido, Num_Candidatos) VALUES ('" + txtCandi.Text + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);

            }
            mthLimpiarCampos();
            mthMostrarDatos();
        }

        private void btnGrafCandi_Click(object sender, EventArgs e)
        {
            FRGraficoPart frm = new FRGraficoPart();
            frm.Show();
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRRedireccion F = new FRRedireccion();
            F.Show();
            this.Hide();
        }

        private void txtPartido_TextChanged(object sender, EventArgs e)
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
    }
}

    

