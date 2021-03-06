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
    public partial class FRVotoDiputado : Form
    {
        string carnet;
        public FRVotoDiputado(string car)
        {
            InitializeComponent();
            carnet = car;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 15";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 15;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 3";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 3;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 21";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 21;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }
        private void FRVotoDiputado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 23";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 23;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 1";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 1;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 6";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 6;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 7";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 7;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 10";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 10;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 16";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 16;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 7";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 7;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 8";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 8;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 9";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 9;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 19";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 19;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 20";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 20;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 2";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 2;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 13";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 13;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 15";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 15;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 22";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 22;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string votos = "SELECT Votos FROM Candidatos WHERE Numero = 24";
            int losvotos = Convert.ToInt16(dbexpo.mthObtenerValor(votos));
            losvotos = losvotos + 1;
            string masvotos = "UPDATE Candidatos SET Votos = " + losvotos.ToString() + " WHERE Numero = 24;";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotos);
            string masvotoss = "UPDATE Votantes SET voto_alcalde = " + 1 + " WHERE Carnet = " + carnet + ";";
            Console.WriteLine(masvotos);
            dbexpo.mthEjecutarOperacion(masvotoss);
            FREspera f = new FREspera(carnet);
            f.Show();
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRVotar f = new FRVotar(carnet);
            f.Show();
            this.Hide();
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRMenuVotante f = new FRMenuVotante(carnet);
            f.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

            

