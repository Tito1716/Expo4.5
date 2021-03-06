using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
namespace EXPO
{
    public partial class Form12 : Form
    {
        string titulo, variable;
        public Form12()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }
        void mthMostrarDatos()
        {
            
            string selecionar = "SELECT Nombre, Edad, Partido FROM Candidatos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label1.Text;
            dataGridView1.Columns[1].HeaderText = label2.Text;
            dataGridView1.Columns[2].HeaderText = label3.Text;
            titulo = "Nombre";
            variable = "Edad";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rango();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            excel exp = new excel();
            exp.ExportarDataGridViewExcel(dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        void rango()
        {
            {
                chart1.Series.Clear();
                chart1.Legends.Clear();
                string datos1 = variable;
                double digitos = 0;

                chart1.Legends.Add(titulo);
                chart1.Legends[0].LegendStyle = LegendStyle.Table;
                chart1.Legends[0].Docking = Docking.Right;
                chart1.Legends[0].Alignment = StringAlignment.Center;
                chart1.Legends[0].Title = titulo;
                chart1.Legends[0].BorderColor = Color.Blue;

                string seriesname1 = datos1;
                chart1.Series.Add(seriesname1);

                chart1.Series[seriesname1].ChartType = SeriesChartType.Range;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    datos1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    digitos = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    this.chart1.Series[seriesname1].Points.AddXY(datos1, digitos);
                }
            }

        }
    }
}
