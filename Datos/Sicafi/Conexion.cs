using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Datos.Sicafi
{
    public class Conexion
    {
        private SqlConnection cn;
        private SqlCommand cmd;
       
        private SqlDataReader dr;
        private string strServidor;
        private string strBaseDatos;
        private string strUsuario;
        private string strClave;
        public Conexion(string strServidor, string strBaseDatos, string strUsuario, string strClave)
        {

            try
            {
                this.strServidor = strServidor;
                this.strBaseDatos = strBaseDatos;
                this.strUsuario = strUsuario;
                this.strClave = strClave;



            }
            catch (Exception exc)
            {
                MessageBox.Show("Desconectado " + exc.Message);
            }
        }

        public SqlDataReader EjecutarConsulta(string sql)
        {
            try
            {
                this.cn = new SqlConnection("Persist Security Info=False;User ID=" + this.strUsuario + ";Password=" + this.strClave + ";Initial Catalog=" + this.strBaseDatos + ";Server=" + this.strServidor);
                this.cn.Open();
                this.cmd = new SqlCommand(sql, this.cn);
                this.dr = this.cmd.ExecuteReader();
                return this.dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public void Desconectar()
        {
            if (this.dr != null)
            {
                this.dr.Dispose();
            }
            if (this.cmd != null)
            {
                this.cmd.Dispose();
            }

            if (this.cn.State == System.Data.ConnectionState.Open)
            {
                this.cn.Close();
                this.cn.Dispose();
            }
        }

    }
}
