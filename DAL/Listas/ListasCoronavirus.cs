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


        //TODO  crear metodo ListadoDeRespuestasPorIdPregunta(int idPregunta) : List<clsRespuesta>



        /// <summary>
        /// <header>clsPregunta GenerarPregunta(SqlDataReader reader)</header>
        /// 
        /// Función que se encarga de extraer un objeto tipo clsPregunta de
        /// la base de datos Coronavirus
        /// <pre>
        ///  reader debe contener los datos de un objeto clsPregunta que se encuentr dentro de la
        ///  base de datos Coronavirus
        /// </pre>
        /// 
        /// <post>
        ///  Devolverá un objeto clsPregunta instanciado y completo en caso de que la base de datos
        ///  no dé problemas en la conexión
        /// </post>
        /// </summary>
        /// <returns></returns>
        private clsPregunta GenerarPregunta(SqlDataReader reader)
        {
            clsPregunta pregunta = null;
            if (reader.HasRows)
            {
                pregunta = new clsPregunta((int)reader["idPregunta"], (string)reader["pregunta"]);
            }
            return pregunta;
        }

        /// <summary>
        /// <header>clsRespuesta GenerarRespuesta(SqlDataReader reader)</header>
        /// 
        /// Función que se encarga de extraer un objeto tipo clsPregunta de
        /// la base de datos Coronavirus
        /// <pre>
        ///  reader debe contener los datos de un objeto clsPregunta que se encuentr dentro de la
        ///  base de datos Coronavirus
        /// </pre>
        /// 
        /// <post>
        ///  Devolverá un objeto clsRespuesta instanciado y completo en caso de que la base de datos
        ///  no dé problemas en la conexión
        /// </post>
        /// </summary>
        /// <returns></returns>
        private clsRespuesta GenerarRespuesta(SqlDataReader reader)
        {
            clsRespuesta respuesta = null;
            if (reader.HasRows)
            {
                respuesta = new clsRespuesta((int)reader["idPregunta"], (int)reader["idRespuesta"], (string)reader["respuesta"], (bool)reader["posibleCaso"]);
            }
            return respuesta;
        }


        /// <summary>
        /// <header>List-clsPregunta- RecogerListadoCompletoPreguntas() </header>
        /// 
        /// <pre>
        ///  La base de datos Debe ser accesible
        /// </pre>
        /// 
        /// <post>
        /// Siempre devolverá el listado completo de preguntas qque se encuentran en la base de datos
        /// </post>
        /// </summary>
        /// <returns></returns>
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



        /// <summary>
        /// <header>List-clsPregunta- RecogerListadoCompletoPreguntas() </header>
        /// 
        /// <pre>
        ///  La base de datos Debe ser accesible
        /// </pre>
        /// 
        /// <post>
        /// Siempre devolverá el listado completo de preguntas qque se encuentran en la base de datos
        /// </post>
        /// </summary>
        /// <returns></returns>
        public List<clsRespuesta> RecogerListadoCompletoRespuestas()
        {
            List<clsRespuesta> respuestas = new List<clsRespuesta>();
            SqlConnection cnn = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            cmd.CommandText = "Select * From respuestas";
            try
            {
                cnn = miConexion.getConnection();
                cmd.Connection = cnn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    respuestas.Add(GenerarRespuesta(reader));
                }




            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cnn != null)
                    miConexion.closeConnection(ref cnn);
                if (reader != null)
                    reader.Close();
            }

            return respuestas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPregunta"></param>
        public List<clsRespuesta> ListadoDeRespuestasPorIdPregunta(int idPregunta)
        {
            List<clsRespuesta> respuestas = new List<clsRespuesta>();

            SqlConnection cnn = null;


            SqlDataReader reader = null;



            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", idPregunta);
                cmd.CommandText = "Select * From respuestas Where idPregunta = @id";
                cnn = miConexion.getConnection();
                cmd.Connection = cnn;
                reader = cmd.ExecuteReader();

               
               
                while(reader.Read())
                respuestas.Add(GenerarRespuesta(reader));

            }
            catch (Exception e)
            {
                throw e;
            }
            return respuestas;
        }
    }
}
