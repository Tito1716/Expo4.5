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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                string usuario, clave, telefono, genero, edad;
                usuario = textBox1.Text;
                clave = textBox2.Text;
                edad = textBox3.Text;
                telefono = textBox5.Text;

                string insertar = "INSERT INTO Login (Usuario, Clave, Telefono, Genero, Edad) VALUES ('" + usuario + "', " + clave + ", " + telefono + ",'" + comboBox1.SelectedValue + "'," + edad + ")";
                EXPO.dbexpo.mthEjecutarOperacion(insertar);
                mthLimpiar();
            }
        }
        void mthLimpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBEXPODataSet.Login' Puede moverla o quitarla según sea necesario.
            this.loginTableAdapter.Fill(this.dBEXPODataSet.Login);
            string dato = "SELECT * FROM Genero ";
            comboBox1.DataSource = dbexpo.mthCargarDatos(dato);
            comboBox1.ValueMember = "Id_genero";
            comboBox1.DisplayMember = "Genero";
            comboBox1.SelectedIndex = -1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
