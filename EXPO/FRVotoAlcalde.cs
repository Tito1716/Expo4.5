using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXPO
{
    public partial class FRVotoAlcalde : Form
    {
        string carnet, titulo;
        public FRVotoAlcalde(string car)
        {
            InitializeComponent();
            carnet = car;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea vota por el alcalde del partido BnL?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                string votos = "SELECT Votos FROM Candidatos WHERE Numero = 14";
                int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
                losvotos = losvotos + 1;
                string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 14;";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotos);
                string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotoss);
                FREspera f = new FREspera(carnet);
                f.Show();
                this.Hide();
            }
        }

        private void FRVotoAlcalde_Load(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }

        void mthMostrarDatos()
        {
            string seleccionar = "SELECT Alcaldes, Imagen FROM Alcaldes";
            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(seleccionar);
            titulo = "Alcaldes";

            string partido = "SELECT * FROM Alcaldes";
            comboBox1.DataSource = dbexpo.mthCargarDatos(partido);
            comboBox1.ValueMember = "id_Alcalde";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.SelectedIndex = -1;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void mthLimpiarCampos()
        {
            txtPartido.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
