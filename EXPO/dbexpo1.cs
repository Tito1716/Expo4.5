using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EXPO
{ 
    class dbexpo1
    {
        SqlConnection Con1 = new SqlConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DBEXPO.accdb");
        private SqlCommandBuilder ConsCom;
        public DataSet DefinirData = new DataSet();
        public SqlDataAdapter AdaptadorDatos;
        public SqlCommand Comando;

        public void Conectarse()
        {
            try
            {
                Con1.Open();
                MessageBox.Show("Conectado correctamente.");
            }
            catch
            {
                MessageBox.Show("Error al conectar.");
            }
            finally
            {
                Con1.Close();
            }
        }
        public void Consulta1(string sql, string Tabla)
        {
            DefinirData.Tables.Clear();
            AdaptadorDatos = new SqlDataAdapter(sql, Con1);
            ConsCom = new SqlCommandBuilder(AdaptadorDatos);
            AdaptadorDatos.Fill(DefinirData, Tabla);
        }
        public bool Insertar(string sql)
        {   
            Con1.Open();
            Comando = new SqlCommand(sql, Con1);
            int i = Comando.ExecuteNonQuery();
            if (1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
