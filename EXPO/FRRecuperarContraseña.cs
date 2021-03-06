using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace EXPO
{
    public partial class FRRecuperarContraseña : Form
    {
        Validacion v = new Validacion();
        public FRRecuperarContraseña()
        {
            InitializeComponent();
        }
        string correo = "marcoskevin1999@hotmail.com";
        string contraseña = "gtasanandreas";
        string key = "mikey";
        correo c = new correo();

        private void Form13_Load(object sender, EventArgs e)
        {
            string om1 = "SELECT * FROM Preguntas";
            comboBox1.DataSource = EXPO.dbexpo.mthCargarDatos(om1);
            comboBox1.ValueMember = "Id_pregunta";
            comboBox1.DisplayMember = "Pregunta";
            comboBox1.SelectedIndex = -1;
        }


        private void modernLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtCarnet.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtRespuesta.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string count = "SELECT Carnet FROM Votantes WHERE Carnet = " + txtCarnet.Text + " AND Pregunta_seguridad = " + comboBox1.SelectedValue + " AND Respuesta ='" + txtRespuesta.Text + "'";
                string vari = Convert.ToString(dbexpo.mthObtenerValor(count));
                if (vari != "")
                {
                    txtCarnet.Text = vari.ToString();
                    object obtenercontra = dbexpo.mthObtenerValor("SELECT Contraseña FROM Votantes WHERE Carnet = " + txtCarnet.Text + "");
                    object obtenercorreo = dbexpo.mthObtenerValor("SELECT Correo_Electronico FROM Votantes WHERE Carnet =" + txtCarnet.Text + "");
                    txtCorreo.Text = Convert.ToString(obtenercorreo);
                    txtContra.Text = Convert.ToString(obtenercontra);
                    enviarcorreo();
                    mthLimpiarDatos();
                    Console.WriteLine(obtenercorreo);
                    Console.WriteLine(count);
                }
                else
                {
                    MessageBox.Show("Los datos que usted ha ingresado son incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void mthLimpiarDatos()
        {
            txtCarnet.Clear();
            txtCorreo.Clear();
            txtRespuesta.Clear();
            comboBox1.SelectedIndex = -1;
            txtContra.Clear();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FRLoginVot f = new FRLoginVot();
            f.Show();
            this.Hide();
        }

        void enviarcorreo()
        {
            MailMessage mail = new MailMessage();
            SmtpClient enviar = new SmtpClient();

            string asunto = "Recuperacion de la contraseña, Voto Electronico, E-Lectronic Inc.";
            {
                try
                {
                    mail.To.Clear();
                    mail.Body = "<h3>Hola, gracias por utilizar nuestro sistema de votacion electronica, ten mas cuidado con tu contraseña.</h3>" + " <Br></Br>" + "<h4>La contraseña para ingresar a nuestro sistema de votacion son:</h4>" + " <Br></Br>" + "<font color=#23598A >Nombre de usuario:</font>" + " <Br></Br> " + txtCarnet.Text + " <Br></Br> " + " <font color =#23598A >Contraseña de su usuario: </font>  <Br></Br> " + txtContra.Text;
                    mail.Subject = asunto;
                    mail.IsBodyHtml = true;
                    mail.To.Add(txtCorreo.Text);
                    mail.From = new MailAddress(correo);
                    enviar.Credentials = new NetworkCredential(correo, contraseña);
                    enviar.Host = "smtp.live.com";
                    enviar.Port = 587;
                    enviar.EnableSsl = true;
                    enviar.Send(mail);
                    MessageBox.Show("Los datos fueron enviados correctamente, por favor revise su e-Mail y verifique los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se enviaron los datos correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolverInicio_Click(object sender, EventArgs e)
        {
            FRRedireccion f = new FRRedireccion();
            f.Show();
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtRespuesta_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
