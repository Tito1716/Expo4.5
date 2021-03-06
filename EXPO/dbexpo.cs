using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;


namespace EXPO
{
    class dbexpo
    {
        static OleDbConnection Conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DBEXPO.accdb");       
        static OleDbCommand ConexionSQL;
       
        public static void mthEjecutarOperacion(string consulta)
        {
            try
            {
                if (MessageBox.Show("¿Desea realizar la operación?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Conexion.Open();
                    ConexionSQL = new OleDbCommand(consulta, Conexion);
                    int rows_afected = ConexionSQL.ExecuteNonQuery();
                    Console.WriteLine(consulta);
                    if (rows_afected > 0) 
                    {
                        MessageBox.Show("¡Operación exitosa!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede realizar la operación en este momento." + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionSQL.Dispose();
            Conexion.Close();
        }
        public static void mthLogin(string consultar)
        {
            try
            {
                Conexion.Open();
                ConexionSQL = new OleDbCommand(consultar, Conexion);
                if (ConexionSQL.ExecuteScalar() != null)
                {
                   
                    Conexion.Close();
                                        
                }
                else
                {
                    MessageBox.Show("Usuario y contraseña no validos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Conexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede realizar la operación en este momento!!." + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionSQL.Dispose();

        }
        public static DataTable mthCargarDatos(string consulta)
        {
            DataTable datos = null;
            try
            {
                Conexion.Open();
                ConexionSQL = new OleDbCommand(consulta, Conexion);
                OleDbDataReader lector = ConexionSQL.ExecuteReader();
                ConexionSQL.Dispose();
                if (lector != null)
                {
                    datos = new DataTable();
                    datos.Load(lector);
                }
                else
                {
                    throw new Exception();
                }
                lector.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede mostrar los datos en este momento: \n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Conexion.Close();
            return datos;
        }
        public static object mthObtenerValor(string consulta)
        {
            object valor = null;
            try
            {
                Conexion.Open();
                ConexionSQL = new OleDbCommand(consulta, Conexion);
                valor = ConexionSQL.ExecuteScalar();
                ConexionSQL.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede obtener el valor en este momento: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Conexion.Close();
            return valor;
        }
    }
}