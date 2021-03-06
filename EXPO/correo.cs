using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Windows.Forms;

namespace EXPO
{
    class correo
    {
        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario/*, string ruta*/, Form NameForm)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                //if (ruta.Equals("") == false)
                //{
                //    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                //    correos.Attachments.Add(archivo);
                //}

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);
                correos.Priority = MailPriority.Normal;
                //Datos importantes no modificables para tener acceso a las cuentas

                envios.Host = "smtp.live.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                MessageBox.Show(NameForm, "Correo enviado Corectamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                string aa = "Verifique el correro o dirreccion web." + ex;
                MessageBox.Show(NameForm, "error" + aa, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        //void contraseña()
        //{
        //    try
        //    {
        //        pb_loader3.Visible = true;
        //        string Nombre = Encriptaciones.Encriptar(txtcorreo.Text.Trim());
        //        string consultar = "SELECT correro_usuario FROM Usuarios WHERE nombre_usuario='" + Nombre + "'";
        //        string correro1 = Convert.ToString(Datos.mtdvalor(consultar, this));
        //        string consultar1 = "SELECT clave_usuario FROM Usuarios WHERE correro_usuario='" + Nombre + "'";
        //        string mensjecontra = Convert.ToString(Datos.mtdvalor(consultar1, this));
        //        string correo = Encriptaciones.Desencriptar(correro1);
        //        string clave = Encriptaciones.Desencriptar(mensjecontra);
        //        string emisor = "daniel_alex_barrera_marroquin@hotmail.com";
        //        string contra = "badjba";
        //        string mensaje = "Hola " + "ten mas cuidado con tu contraseña.  " + " tu contraseña es  " + clave + " ya puedes iniciar sesion";
        //        string asunto = "Recuperacion de Contraseña";
        //        c.enviarCorreo(emisor, contra, mensaje, asunto, correo, this);
        //        pb_loader3.Visible = false;
        //    }
        //    catch (Exception aa)
        //    {
        //        MetroMessageBox.Show(this, "error" + aa, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        pb_loader3.Visible = false;
        //    }
        //}
    }
}
