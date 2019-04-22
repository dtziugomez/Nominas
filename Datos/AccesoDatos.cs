using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoDatos
    {

        public static DataTable ObtenerEmpleados()
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "SELECT "+
                " *FROM Empleados WHERE Eliminado=0";
            return MetodosDatos.EjecutarComandoSelect(_comando);
        }

        public static DataTable ObtenerDepartamentos()
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "SELECT * FROM Departamentos";
            return MetodosDatos.EjecutarComandoSelect(_comando);
        } 

        public static DataTable ObtenerEmpleado(int idEmpleado)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "SELECT * FROM Empleados WHERE idEmpleado=" + idEmpleado;
            return MetodosDatos.EjecutarComandoSelect(_comando);
        }
        public static void InsertarEmpleado(string nombre,string apellidos,string telefono,string direccion,
            string fechaIngreso,string sueldoBase,string idDepto)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            
            _comando.CommandText = "INSERT INTO Empleados(Nombre,Apellidos" +
                ",Telefono,Direccion,FechaIngreso,SueldoBase,idDepartamento) VALUES('" +
                nombre + "','" + apellidos + "','" + telefono + "','" +
                direccion + "','" + fechaIngreso + "'," + sueldoBase + "," + idDepto + ")";
            MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
        }

        public static void ActualizarEmpleado(string nombre, string apellidos, string telefono, string direccion,
            string fechaIngreso, string sueldoBase, string idDepto,int idEmpleado)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            
            _comando.CommandText = "UPDATE Empleados " +
                "SET Nombre='" +
                nombre + "',Apellidos='" + apellidos + "',Telefono='" + telefono + "',Direccion='" +
                direccion + "',FechaIngreso='" + fechaIngreso + "',SueldoBase=" + sueldoBase +
                ",idDepartamento=" +idDepto+" WHERE idEmpleado="+idEmpleado;
            MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
        }

        public static void EliminarEmpleado(int idEmpleado)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            DataTable empleado = ObtenerEmpleado(idEmpleado);
            _comando.CommandText = "UPDATE Empleados " +
                "SET Eliminado=1" +
                " WHERE idEmpleado=" + idEmpleado;
            MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
        }

        public static void ActualizarTabulador(int idEmpleado,decimal sueldo)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            
            _comando.CommandText = "UPDATE Empleados " +
                "SET SueldoBase='" + sueldo.ToString() +
                 "' WHERE idEmpleado=" + idEmpleado;
            MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
        }


        public static void InsertarNomina(int idEmpleado, int diasTrabajados,
            int horasExtra, string periodoD, string periodoH)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();

            _comando.CommandText = "INSERT INTO Nominas(idEmpleado" +
                ",diasTrabajados,horasExtras,periodoDesde,periodoHasta,fechaCreacion) VALUES('" +
                idEmpleado + "','" + diasTrabajados + "','" + horasExtra + "','" +
                periodoD + "','" + periodoH + "',getdate())";
            MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
        }

        public static int yaTieneNomina(int idEmpleado)
        {
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "select COUNT(*) from Nominas where idEmpleado=" +
                idEmpleado + " and day(fechaCreacion) = day(GETDATE()) and "+
  "month(fechaCreacion) = month(GETDATE()) and "+
  "year(fechaCreacion) = year(GETDATE())";
            return MetodosDatos.yaTieneNomina(_comando);
        }

        public static DataTable ObtenerNominas(int idEmpleado,int tipoBusqueda)
        {
            return MetodosDatos.NominasEmpleado(idEmpleado,tipoBusqueda);
        }

        public static bool InsertarDepartamento(string nombre)
        {
            bool resultado = false;
            SqlCommand _comando = MetodosDatos.CrearComando();
            _comando.CommandText = "SELECT count(*) FROM Departamentos where Descripcion='" + nombre+"'";
            resultado = MetodosDatos.ExisteDepartamento(_comando);
            if (resultado==false)
            {
                _comando.CommandText = "INSERT INTO Departamentos(Descripcion)" +
                " Values('" + nombre + "')";
                MetodosDatos.EjecutarComandoUpdateOInsertODelete(_comando);
            }
            return resultado;
        }

        

    }
}
