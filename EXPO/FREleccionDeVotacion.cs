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
    public partial class FREleccionDeVotacion : Form
    {
        string carnet;
        public FREleccionDeVotacion(string c)
        {
            InitializeComponent();
            carnet = c;
        }

        private void FREleccionDeVotacion_Load(object sender, EventArgs e)
        {
            string pregun = "SELECT * FROM VotoFecha";
            comboBox1.DataSource = EXPO.dbexpo.mthCargarDatos(pregun);
            comboBox1.ValueMember = "Id_voto";
            comboBox1.DisplayMember = "Voto";
            comboBox1.SelectedIndex = -1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int seleccion = Convert.ToInt32(comboBox1.SelectedValue);

            switch (seleccion)
            {

                case 1:

                    FRVotar f = new FRVotar(carnet);
                    f.Show();
                    this.Hide();
                    break;

                case 2:
                    FRVotar f2 = new FRVotar(carnet);
                    f2.Show();
                    this.Hide();
                    break;

                case 3:
                    FRVotar f3 = new FRVotar(carnet);
                    f3.Show();
                    this.Hide();
                    break;

                case 4:
                    FRVotar f4 = new FRVotar(carnet);
                    f4.Show();
                    this.Hide();
                    break;

                case 5:
                    FRVotar f5 = new FRVotar(carnet);
                    f5.Show();
                    this.Hide();
                    break;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRMenuVotante F = new FRMenuVotante(carnet);
            F.Show();
            this.Hide();
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRMenuVotante F = new FRMenuVotante(carnet);
            F.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
