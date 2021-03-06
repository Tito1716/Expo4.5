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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" && textBox1.Text.Trim() != "")
            {
                string consultar = "SELECT Carnet FROM Votantes WHERE Carnet = " + textBox1.Text + " AND Contraseña =" + textBox2.Text;
                EXPO.dbexpo.mthLogin(consultar);
                string contar = "SELECT Carnet FROM Votantes WHERE Carnet =" + textBox1.Text + " AND Contraseña =" + textBox2.Text;
                string variable = Convert.ToString(EXPO.dbexpo.mthObtenerValor(contar));
                if (variable != "")
                {
                    mthLimpiar();
                    Form8 form2 = new Form8();
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

    


    private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form13 f = new Form13();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 F = new Form10();
            F.Show();
            this.Hide();
        }
    }
}
