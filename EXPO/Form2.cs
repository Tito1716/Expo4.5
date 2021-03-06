using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace EXPO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mthMostrarDatos();
        }
        void mthMostrarDatos()
        {
            mthLimpiarCampos();
            string selecionar = "SELECT Numero, Nombre, Partido, Imagen FROM Candidatos";

            dataGridView1.DataSource = EXPO.dbexpo.mthCargarDatos(selecionar);

            dataGridView1.Columns[0].HeaderText = label1.Text;
            dataGridView1.Columns[1].HeaderText = label2.Text;
            dataGridView1.Columns[2].HeaderText = label3.Text;
            dataGridView1.Columns[3].Visible = false;
            
        }
        void mthLimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                string Eliminar = "DELETE FROM Candidatos WHERE Numero = " + textBox1.Text;
                dbexpo.mthEjecutarOperacion(Eliminar);
                mthMostrarDatos();
                button3.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                string insertar = "INSERT INTO Candidatos (Numero, Nombre, Partido) VALUES ('" + textBox2.Text + "','" + textBox3.Text + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);

            }
            mthLimpiarCampos();
            mthMostrarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {


                string modificar = "UPDATE Candidatos SET Nombre='" + textBox2.Text + "', Partido=" + textBox3.Text + " WHERE Numero =" + textBox1.Text;
                MessageBox.Show(modificar);
                EXPO.dbexpo.mthEjecutarOperacion(modificar);
            }
            button3.Visible = true;
            button4.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.Show();
            this.Hide();
        }
    }
}

