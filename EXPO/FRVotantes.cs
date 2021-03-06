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
    public partial class FRVotantes : Form
    {
        public FRVotantes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtCarnet.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string seleccionar = "SELECT * FROM Votantes";
            comboBox1.DataSource = dbexpo.mthCargarDatos(seleccionar);
            comboBox1.ValueMember = "Carnet";
            comboBox1.DisplayMember = "Nombres";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRRedireccion F = new FRRedireccion();
            F.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }
        void mthMostrarDatos()
        {
            mthLimpiarCampos();
            string selecionar = "SELECT Carnet, Nombres, Edad FROM Votantes";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label1.Text;
            dataGridView1.Columns[1].HeaderText = label2.Text;
            dataGridView1.Columns[2].HeaderText = label3.Text;

        }
        void mthLimpiarCampos()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "")
            {
                string insertar = "INSERT INTO Votantes (Carnet, Nombre, Edad) VALUES ('" + txtNombre.Text + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);

            }
            mthLimpiarCampos();
            mthMostrarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCarnet.Text != "")
            {
                string Eliminar = "DELETE FROM Votantes WHERE Carnet = " + txtCarnet.Text;
                dbexpo.mthEjecutarOperacion(Eliminar);
                mthMostrarDatos();
                btnGuardar.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCarnet.Text.Trim() != "" && txtNombre.Text.Trim() != "")
            {
                string modificar = "UPDATE Partidos SET Partido='" + txtCarnet.Text + "', Num_Candidatos=" + txtNombre.Text + " WHERE Id_libro =" + txtCarnet.Text;
                MessageBox.Show(modificar);
                EXPO.dbexpo.mthEjecutarOperacion(modificar);
            }
            btnModificar.Visible = true;
            btnGuardar.Visible = false;
        }

        private void btnGrafCandi_Click(object sender, EventArgs e)
        {
            FRGraficoVot form = new FRGraficoVot();
            form.Show();
            this.Hide();
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
    
    

