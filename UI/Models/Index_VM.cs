using BL.Listas;
using Entities;

namespace UI.Models
{
    public class Index_VM
    {
        private ListasCoronavirusBL bl = new ListasCoronavirusBL();
        public List<clsPregunta> preguntas { get; }

        public List<clsRespuesta> respuestas { get; }


        public List<clsPreguntaConRespuestas> preguntasConRespuestas { get; set; }

        public Index_VM()
        {
            preguntasConRespuestas = new List<clsPreguntaConRespuestas>();
            respuestas = bl.RecogerListadoCompletoRespuestasBL();
            preguntas = bl.RecogerListadoCompletoPreguntasBL();
            foreach(var pregunta in preguntas)
            {
                List<clsRespuesta> r = new List<clsRespuesta>();
                foreach (var respuesta in respuestas)
                {
                    

                    if(pregunta.IdPregunta == respuesta.IdPregunta)
                    {
                        r.Add(respuesta);
                    }
                    
                }
                preguntasConRespuestas.Add(new clsPreguntaConRespuestas(pregunta, r));


            }
        }



    }
}
