using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsRespuesta
    {

        public int IdRespuesta { get; set; }
  
        public int IdPregunta { get;}


        public string Respuesta { get; set; }

        public bool PosibleCaso { get; set; }

        public clsRespuesta(int idPregunta) { IdPregunta = idPregunta; }


    }
}
