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

        public bool PosibleCaso { get; set; }

        public clsRespuesta(int idPregunta) { IdPregunta = idPregunta; IdRespuesta = idPregunta; }

        public clsRespuesta() { }


        public void establecerPosibleCaso()
        {
            if(!(this.Respuesta.Equals("No") || this.Respuesta.Equals("Entre 37º y 38º")))
            {
                this.PosibleCaso = true;
            }
        }
    }
}
