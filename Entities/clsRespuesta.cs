using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsRespuesta
    {

        public int IdRespuesta { get; set; }
  
        public int IdPregunta { get;}

        [Required(ErrorMessage = "Es necesario responder todas las preguntas")]
        public string Respuesta { get; set; }
        [Required(ErrorMessage = "Es necesario responder a todas las preguntas")]
        public bool PosibleCaso { get; set; }

        public clsRespuesta(int idPregunta) { IdPregunta = idPregunta; IdRespuesta = idPregunta; }

        public clsRespuesta() { }


        public clsRespuesta(int idPregunta, int idRespuesta, string respuesta, bool posibleCaso)
        {
            IdPregunta = idPregunta;
            Respuesta = respuesta;
            PosibleCaso = posibleCaso;
            IdRespuesta = idRespuesta;
        }
    }
}
