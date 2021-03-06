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
    public partial class FRVotar : Form
    {
        string carnet;
        public FRVotar(string car)
        {
            InitializeComponent();
            carnet = car;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selecionar = "SELECT estado_voto  FROM Votantes  WHERE Carnet = " + carnet + "";
            string mensjecontra = Convert.ToString(dbexpo.mthObtenerValor(selecionar));
            if (mensjecontra == "1")
            {
                MessageBox.Show("Usted ya realizo su voto");
            }
            else if (mensjecontra == "2")
            {
                FRVotandoPartido f = new FRVotandoPartido(carnet);
                f.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selecionar = "SELECT voto_alcalde  FROM Votantes  WHERE Carnet = " + carnet + "";
            string mensjecontra = Convert.ToString(dbexpo.mthObtenerValor(selecionar));
            if (mensjecontra == "1")
            {
                MessageBox.Show("Usted ya realizo su voto");
            }
            else if (mensjecontra == "2")
            {
                FRVotoAlcalde f = new FRVotoAlcalde(carnet);
                f.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selecionar = "SELECT voto_diputado  FROM Votantes  WHERE Carnet = " + carnet + "";
            string mensjecontra = Convert.ToString(dbexpo.mthObtenerValor(selecionar));
            if (mensjecontra == "1")
            {
                MessageBox.Show("Usted ya realizo su voto");
            }
            else if (mensjecontra == "2")
            {
                FRVotoDiputado f = new FRVotoDiputado(carnet);
                f.Show();
                this.Hide();
            }
        }

        private void FRVotar_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FREleccionDeVotacion f = new FREleccionDeVotacion(carnet);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
