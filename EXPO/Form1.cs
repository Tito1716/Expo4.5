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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string variable)
        {
            this.variable = variable;
        }
        string key = "llave";
        private readonly string variable;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" && textBox1.Text.Trim() != "")
            {
                string consultar = "SELECT Usuario FROM Login WHERE Usuario = '" + textBox1.Text + "' AND Clave =" + textBox2.Text;
                EXPO.dbexpo.mthLogin(consultar);
                string contar = "SELECT Usuario FROM Login WHERE Usuario ='" + textBox1.Text + "' AND Clave =" + textBox2.Text;
                string variable = Convert.ToString(EXPO.dbexpo.mthObtenerValor(contar));
                if (variable != "")
                {
                    mthLimpiar();
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }

            }
        }
        void mthLimpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 F = new Form10();
            F.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form10 F = new Form10();
            F.Show();
            this.Hide();
        }
    }
}
