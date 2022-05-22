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
