using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EXPO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }
        void mthMostrarDatos()
        {
            mthLimpiarCampos();
            string selecionar = "SELECT Partido, Num_Candidatos FROM Partidos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label1.Text;
            dataGridView1.Columns[1].HeaderText = label2.Text;

        }
        void mthLimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string Eliminar = "DELETE FROM Partidos WHERE Partido = " + textBox1.Text;
                dbexpo.mthEjecutarOperacion(Eliminar);
                mthMostrarDatos();
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                string insertar = "INSERT INTO Partidos (Partido, Num_Candidatos) VALUES ('" + textBox2.Text + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);

            }
            mthLimpiarCampos();
            mthMostrarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {


                string modificar = "UPDATE Partidos SET Partido='" + textBox1.Text + "', Num_Candidatos=" + textBox2.Text + " WHERE Id_libro =" + textBox1.Text;
                MessageBox.Show(modificar);
                EXPO.dbexpo.mthEjecutarOperacion(modificar);
            }
            button4.Visible = true;
            button3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

    

