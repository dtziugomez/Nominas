using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class MetodosDatos
    {

        public static SqlCommand CrearComando()
        {
            string _cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand _comando = new SqlCommand();
            _comando = _conexion.CreateCommand();
            _comando.CommandType = CommandType.Text;
            return _comando;
        }

        
        public static DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { comando.Connection.Close(); }
            return _tabla;
        }

        public static void EjecutarComandoUpdateOInsertODelete(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                int res = comando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { comando.Connection.Close(); }
        }

        public static int yaTieneNomina(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            int valor = 0;
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);
                
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { comando.Connection.Close();
                foreach (DataRow dtRow in _tabla.Rows)
                {
                    foreach (DataColumn dc in _tabla.Columns)
                    {
                        valor = Convert.ToInt32(dtRow[dc].ToString());
                    }
                }
                
            }
            return valor;
        }

        public static DataTable NominasEmpleado(int clave,int tipoBusqueda)
        {
            DataTable dt = new DataTable();
            try
            {
                
                string _cadenaConexion = Configuracion.CadenaConexion;
                SqlConnection _conexion = new SqlConnection();
                _conexion.ConnectionString = _cadenaConexion;
                SqlDataAdapter da = new SqlDataAdapter("usp_spConsultarNominas", _conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@clave", SqlDbType.Int);
                da.SelectCommand.Parameters["@clave"].Value = clave;
                da.SelectCommand.Parameters.Add("@tipoBusqueda", SqlDbType.Int);
                da.SelectCommand.Parameters["@tipoBusqueda"].Value = tipoBusqueda;
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static bool ExisteDepartamento(SqlCommand comando)
        {
            DataTable dt = new DataTable();
            bool valor = false;
            try
            {
                comando.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                comando.Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (Convert.ToInt32(dr[dc].ToString()) == 0)
                        {
                            valor = false;
                        }
                        else valor = true;
                    }
                }
            }
            return valor;
        }
        
    }
}
