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

namespace EXPO
{
    public partial class FRCandidatos : Form
    {
        Point point = new Point();
        int x, y;
        public FRCandidatos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNumero.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGenero.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPartido.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtZona.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            btnModificar.Visible = true;
            btnGuardar.Visible = false;
            btnImagen.Visible = false;
            btnEliminar.Visible = false;
        }

        private void FRCandidatos_Load(object sender, EventArgs e)
        {
            string seleccionar = "SELECT * FROM Candidatos";
            cBxBuscar.DataSource = dbexpo.mthCargarDatos(seleccionar);
            cBxBuscar.ValueMember = "Numero";
            cBxBuscar.DisplayMember = "Nombre";
            cBxBuscar.SelectedIndex = -1;
            cBxBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            cBxBuscar.AutoCompleteSource = AutoCompleteSource.ListItems;
            mthMostrarDatos();
            btnModificar.Visible = false;
            btnGuardar.Visible = false;
            btnImagen.Visible = false;
            btnEliminar.Visible = false;
        }

        void mthMostrarDatos()

        {
            mthLimpiarCampos();
            string selecionar = "SELECT Nombre, Numero, Edad, Genero, Partido, Zona, Imagen FROM Candidatos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label2.Text;
            dataGridView1.Columns[1].HeaderText = label1.Text;
            dataGridView1.Columns[2].HeaderText = label10.Text;
            dataGridView1.Columns[3].HeaderText = label9.Text;
            dataGridView1.Columns[4].HeaderText = label3.Text;
            dataGridView1.Columns[5].HeaderText = label8.Text;
            dataGridView1.Columns[6].Visible = false;
        }

        void mthLimpiarCampos()
        {
            txtNombre.Clear();
            txtNumero.Clear();
            txtPartido.Clear();
            txtZona.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "" && txtNumero.Text.Trim() != "" && txtPartido.Text.Trim() != "")
            {
                string modificar = "UPDATE Candidatos SET Nombre='" + txtNombre.Text + "', Partido=" + txtPartido.Text + " WHERE Numero =" + txtNumero.Text;
                MessageBox.Show(modificar);
                EXPO.dbexpo.mthEjecutarOperacion(modificar);
            }
            btnGuardar.Visible = true;
            btnModificar.Visible = false;
            btnImagen.Visible = true;
            btnEliminar.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                string Eliminar = "DELETE FROM Candidatos WHERE Numero = " + txtNumero.Text;
                dbexpo.mthEjecutarOperacion(Eliminar);
                mthMostrarDatos();
                btnGuardar.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrafCandi_Click(object sender, EventArgs e)
        {
            FRGraficoCand f = new FRGraficoCand();
            f.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "")
            {
                string insertar = "INSERT INTO Candidatos (Numero, Nombre, Partido) VALUES ('" + txtNombre.Text + "','" + txtPartido.Text + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);

            }
            mthLimpiarCampos();
            mthMostrarDatos();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRRedireccion F = new FRRedireccion();
            F.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRCandidatos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point = Control.MousePosition;
                point.X -= x;
                point.Y -= y;
                this.Location = point;
                Application.DoEvents();
            }
        }

        private void FRCandidatos_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - this.Location.X;
            y = Control.MousePosition.Y - this.Location.Y;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - this.Location.X;
            y = Control.MousePosition.Y - this.Location.Y;
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
            FRRedireccion fr = new FRRedireccion();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cBxZona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fechayhora.Text = DateTime.Now.ToString();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point = Control.MousePosition;
                point.X -= x;
                point.Y -= y;
                this.Location = point;
                Application.DoEvents();
            }
        }
    }
}

