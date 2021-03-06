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
    public partial class FREsperaExportar : Form
    {
        string export;
        public FREsperaExportar(String ex)
        {
            InitializeComponent();
            export = ex;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                FRGraficoCand f = new FRGraficoCand();
                f.Show();
                this.Hide();
                MessageBox.Show("Se ha exportado el archivo en formato PDF con éxito",
                "¡Exportación completa!");
            }
        }

        private void FREsperaExportar_Load(object sender, EventArgs e)
        {

        }
    }
}
