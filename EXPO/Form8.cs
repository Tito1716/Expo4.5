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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        void VotoExitoso()
        {
            pictureBox1.Width = 938;
            pictureBox1.Height = 588;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {if(MessageBox.Show("¿Desea vota por el partido BnL?","Aviso",MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)== DialogResult.Yes)
            {
                string votos = "SELECT Votos FROM Partidos WHERE id_Partido = 1";
                int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
                losvotos = losvotos + 1;
                string masvotos = "UPDATE Partidos SET Votos = " + losvotos.ToString() + " WHERE id_Partido = 1;";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotos);
                VotoExitoso();
                
            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile("imagenes/koala.png");
            button2.Image = Image.FromFile("imagenes/koala.png");
            button3.Image = Image.FromFile("imagenes/koala.png");
            button4.Image = Image.FromFile("imagenes/koala.png");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea vota por el partido DSR-50?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                string votos = "SELECT Votos FROM Partidos WHERE id_Partido = 2";
                int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
                losvotos = losvotos + 1;
                string masvotos = "UPDATE Partidos SET Votos = " + losvotos.ToString() + " WHERE id_Partido = 2;";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotos);
                VotoExitoso();
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea vota por el partido Machinima?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                string votos = "SELECT Votos FROM Partidos WHERE id_Partido = 3";
                int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
                losvotos = losvotos + 1;
                string masvotos = "UPDATE Partidos SET Votos = " + losvotos.ToString() + " WHERE id_Partido = 3;";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotos);
                VotoExitoso();
               
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea vota por el partido MGS?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                string votos = "SELECT Votos FROM Partidos WHERE id_Partido = 4";
                int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
                losvotos = losvotos + 1;
                string masvotos = "UPDATE Partidos SET Votos = " + losvotos.ToString() + " WHERE id_Partido = 4;";
                Console.WriteLine(masvotos);
                dbexpo.mthEjecutarOperacion(masvotos);
                VotoExitoso();
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
