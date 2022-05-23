using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Gestion
{
    public class GestionCoronavirus
    {

        private clsMyConnection miConexion = new clsMyConnection();



        /// <summary>
        ///  <header>InsertarPersona(clsPersona persona)</header>
        /// </summary>
        /// <pre>
        /// El valor del atributo DniPersona del objeto clsPersona proporcionado
        /// debe ser único. Es decir, no debe existir dentro de la base de datos
        /// </pre>
        /// 
        /// <post>
        /// Se insertará la persona en la base de datos mediante un query.
        /// Devolverá 1 si ha sido introducida y 0 si no ha podido ser introducida
        /// por fallos en la base de datos
        /// </post>
        /// <param name="persona"></param>
        /// <returns>filasAfectadas: entero extraido de el conteo de filas afectadas en la base de datos
        /// tras realizar la query</returns>
        public int InsertarPersona(clsPersona persona)
        {
            int filasAfectadas = 0;
            SqlCommand cmd  = new SqlCommand();
            cmd.Parameters.AddWithValue("@dni", persona.DniPersona);
            cmd.Parameters.AddWithValue("@nombre", persona.NombrePersona);
            cmd.Parameters.AddWithValue("@apellidos", persona.ApellidosPersona);
            cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
            cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
            cmd.Parameters.AddWithValue("@diagnostico", persona.Diagnostico);
            cmd.CommandText = "Insert into personas(dniPersona, nombrePersona, apellidosPersona, telefono, direccion, diagnostico) Values(@dni, @nombre, @apellidos, @telefono, @direccion, @diagnostico)";
            try
            {
                cmd.Connection = miConexion.getConnection();
                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return filasAfectadas;
        }
    }
}
