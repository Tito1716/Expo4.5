using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Data.OleDb;

namespace EXPO
{
    public partial class Form7 : Form
    {
        string titulo, variable;
        public Form7()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }
        void mthMostrarDatos()
        {
            string seleccionar = "SELECT Carnet, Nombres, Edad FROM Votantes";
            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(seleccionar);
            dataGridView1.Columns[0].HeaderText = label2.Text;
            dataGridView1.Columns[1].HeaderText = label4.Text;
            dataGridView1.Columns[2].HeaderText = label5.Text;
            titulo = "Nombres";
            variable = "Edad";


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
                    datos1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    digitos = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());

                    this.chart1.Series[seriesname1].Points.AddXY(datos1, digitos);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pdf();
        }
        void pdf()
        {
            try
            {
                SaveFileDialog h = new SaveFileDialog();
                h.Filter = "Pdf(*.pdf)|*.pdf";
                h.FileName = "pdf";
                if (h.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.LETTER);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(h.FileName, FileMode.Create));
                    doc.Open();



                    doc.Add(new Paragraph(" "));
                    PdfPTable c = new PdfPTable(dataGridView1.Columns.Count);
                    doc.Add(c);
                    var chartimage = new MemoryStream();
                    chart1.SaveImage(chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                    doc.Add(Chart_image);


                    doc.Add(new Paragraph(""));

                    PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                        table.SetWidthPercentage(new float[] { 40, 80 }, PageSize.LETTER);

                    }

                    table.HeaderRows = 1;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int k = 0; k < dataGridView1.Columns.Count; k++)
                        {
                            if (dataGridView1[k, i].Value != null)
                            {
                                table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                            }
                        }
                    }

                    doc.Add(table);

                    doc.Add(new Paragraph(" "));
                    Paragraph pie = new Paragraph("¡GRACIAS POR CONSULTAR!", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD));
                    pie.Alignment = Element.ALIGN_CENTER;
                    doc.Add(pie);
                    doc.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + e.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            excel exp = new excel();
            exp.ExportarDataGridViewExcel(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rango();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
