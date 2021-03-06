﻿using System;
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
    public partial class FRGraficoCand : Form
    {
        Point point = new Point();
        int x, y;
        string titulo, rut, export, ex, variable, carnet;
        public FRGraficoCand()
        {
            InitializeComponent();
            export = ex;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            rango();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
           mthMostrarDatos();
        }

        void mthMostrarDatos()
        {

            string selecionar = "SELECT Nombre, Edad, Partido FROM Candidatos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label1.Text;
            dataGridView1.Columns[2].HeaderText = label3.Text;
            titulo = "Nombre";
            variable = "Edad";
        }

        private void btnExExc_Click(object sender, EventArgs e)
        {
            excel exp = new excel();
            exp.ExportarDataGridViewExcel(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPartido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRCandidatos f = new FRCandidatos();
            f.Show();
            this.Hide();
        }

        private void FRGraficoCand_MouseMove(object sender, MouseEventArgs e)
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
        private void FRGraficoCand_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - this.Location.X;
            y = Control.MousePosition.Y - this.Location.Y;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - this.Location.X;
            y = Control.MousePosition.Y - this.Location.Y;
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

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion fr = new FRRedireccion();
            fr.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExPDF_Click(object sender, EventArgs e)
        {
            pdf();
            FREsperaExportar f = new FREsperaExportar(ex);
            f.Show();
            this.Hide();
        }

        void pdf()
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.FileName = "Grafico de candidatos";
                fichero.Filter = "Pdf(*.pdf)|*.pdf";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.LETTER, 20, 20, 20, 20);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(fichero.FileName, FileMode.Create));
                    doc.Open();
                    PdfPTable encabezado = new PdfPTable(3);
                    var chartimage = new MemoryStream();
                    encabezado.SetWidthPercentage(new float[] { 170, 170, 170 }, PageSize.LETTER);
                    encabezado.AddCell(iTextSharp.text.Image.GetInstance("imagenes/Logo.png"));
                    encabezado.AddCell(new Paragraph("E-Lectonic Inc. \n \nPartidos", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL)));
                    encabezado.AddCell(new Paragraph("Partidos\n Voto Electronico\n", FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL)));
                    foreach (PdfPCell celda in encabezado.Rows[0].GetCells())
                    {
                        celda.BackgroundColor = BaseColor.WHITE;
                        celda.HorizontalAlignment = 5;
                        celda.VerticalAlignment = 5;
                        celda.Border = 0;
                        celda.BorderWidthBottom = 4f;
                        celda.BorderWidthTop = 4f;
                        celda.BorderColorBottom = new BaseColor(80, 80, 80);
                        celda.BorderColorTop = new BaseColor(80, 80, 80);
                    }
                    doc.Add(encabezado);
                    doc.Add(new Paragraph(" "));
                    iTextSharp.text.Font fontTable = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                    table.DefaultCell.Phrase = new Phrase() { Font = fontTable };
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText, fontTable));
                        table.SetWidthPercentage(new float[] { 100, 100, 100 }, PageSize.LETTER);
                    }
                    table.HeaderRows = 1;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        foreach (PdfPCell celdas in table.Rows[i].GetCells())
                        {
                            celdas.BorderWidth = 1f;
                            celdas.BorderColor = new BaseColor(80, 80, 80);
                        }
                        foreach (PdfPCell celdas in table.Rows[0].GetCells())
                        {
                            celdas.BorderWidth = 1f;
                            celdas.BackgroundColor = new BaseColor(129, 211, 255);
                        }
                        for (int k = 0; k < dataGridView1.Columns.Count; k++)
                        {
                            if (dataGridView1[k, i].Value != null)
                            {
                                table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString(), fontTable));
                            }
                        }
                    }
                    doc.Add(table);
                    doc.Add(new Paragraph(" "));
                    chart1.SaveImage(chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                    image1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(image1);
                    Paragraph pie = new Paragraph("¡Gracias por utilizar nuestro sistema!", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLDITALIC));
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