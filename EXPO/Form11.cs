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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar('\r'))
            {
                MessageBox.Show(textBox1.Text);

            }
        }
        private bool comparCodi(string codigo)
        {
            if (codigo == "1234567890")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string leido = textBox1.Text;
            if(comparaCodi(textBox1.Text)==true)
            {
                label1.Text = "Tarjeta OK";
            }
            else 
            {
                label1.Text = "Tarjeta No Valida";
            }
        }
    }
}
