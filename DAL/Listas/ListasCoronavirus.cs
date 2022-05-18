using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entities;

namespace DAL.Listas
{
   public class ListasCoronavirus
    {
        clsMyConnection miConexion = new clsMyConnection();

        private clsPregunta GenerarPregunta(SqlDataReader reader)
        {
            clsPregunta pregunta = null;
            if (reader.HasRows)
            {
                pregunta = new clsPregunta((int)reader["idPregunta"], (string)reader["pregunta"]);
            }
            return pregunta;
        }




        public List<clsPregunta> RecogerListadoCompletoPreguntas() 
        { 
            List<clsPregunta> preguntas = new List<clsPregunta>();
            SqlConnection cnn = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            cmd.CommandText = "Select * From preguntas";
            try
            {   
                cnn = miConexion.getConnection();
                cmd.Connection = cnn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    preguntas.Add(GenerarPregunta(reader));
                }

                


            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(cnn != null)
                    miConexion.closeConnection(ref cnn);
                if (reader != null)
                    reader.Close();
            }

            return preguntas;
        }
    }
}
