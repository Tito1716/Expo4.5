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
    public partial class FRVotandoPartido : Form
    {
        DateTime localDate = DateTime.Now;
        string carnet, titulo;
        public FRVotandoPartido(string c)
        {
            InitializeComponent();
            carnet = c;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }

        void mthMostrarDatos()
        {
            string seleccionar = "SELECT Partido, Imagen FROM Partidos";
            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(seleccionar);
            titulo = "Partidos";
            dataGridView1.Columns[1].Visible = false;

            string partido = "SELECT * FROM Partidos";
            comboBox1.DataSource = dbexpo.mthCargarDatos(partido);
            comboBox1.ValueMember = "id_Partido";
            comboBox1.DisplayMember = "Partido";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void mthLimpiarCampos()
        {
            txtPartido.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRVotoDiputado f = new FRVotoDiputado(carnet);
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FRVotoAlcalde f = new FRVotoAlcalde(carnet);
            f.Show();
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRVotar f = new FRVotar(carnet);
            f.Show();
            this.Hide();
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRMenuVotante f = new FRMenuVotante(carnet);
            f.Show();
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPartido.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pictureBox2.ImageLocation = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
