using System.Data;
using Datos;
using System;

namespace Logica
{
    public class AccesoLogica
    {

        public static DataTable ObtenerEmpleados()
        {
            return AccesoDatos.ObtenerEmpleados();
        }

        public static DataTable ObtenerEmpleado(int idEmpleado)
        {
            return AccesoDatos.ObtenerEmpleados();
        }

        public static void InsertaEmpleado(string nombre, string apellidos, string telefono, string direccion,
            string fechaIngreso, string sueldoBase, string idDepto)
        {
            AccesoDatos.InsertarEmpleado(nombre, apellidos, telefono, direccion,
            fechaIngreso, sueldoBase, idDepto);
        }

        public static void ActualizaEmpleado(string nombre, string apellidos, string telefono, string direccion,
            string fechaIngreso, string sueldoBase, string idDepto, int idEmpleado)
        {
            AccesoDatos.ActualizarEmpleado(nombre, apellidos, telefono, direccion,
            fechaIngreso, sueldoBase, idDepto, idEmpleado);
        }

        public static void EliminaEmpleado(int idEmpleado)
        {
            AccesoDatos.EliminarEmpleado(idEmpleado);
        }

        public static DataTable ObtenerDepartamentos()
        {
            return AccesoDatos.ObtenerDepartamentos();
        }

        public static void ActualizaTabulador(int idEmpleado, decimal sueldo)
        {
            AccesoDatos.ActualizarTabulador(idEmpleado, sueldo);
        }

        public static void InsertaNomina(int idEmpleado, int diasTrabajados,
            int horasExtra, string periodoD, string periodoH)
        {
            if (AccesoDatos.yaTieneNomina(idEmpleado)==0)
            {
                AccesoDatos.InsertarNomina(idEmpleado, diasTrabajados,
            horasExtra, periodoD, periodoH);
            }
            
        }

        public static DataTable ObtenerNominasEmpleado(int idEmpleado,int tipoBusqueda)
        {
            return AccesoDatos.ObtenerNominas(idEmpleado,tipoBusqueda);
        }
        public static bool InsertaDepartamento(string descripcion)
        {
            return AccesoDatos.InsertarDepartamento(descripcion);
        }

    }
}
