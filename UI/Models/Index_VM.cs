using BL.Listas;
using Entities;

namespace UI.Models
{
    public class Index_VM
    {
        private ListasCoronavirusBL bl = new ListasCoronavirusBL();
        private List<clsPregunta> preguntas { get; }

        private List<clsRespuesta> respuestas;


        public List<clsPreguntaConRespuestas> preguntasConRespuestas { get; set; }

        public Index_VM()
        {
            
            respuestas = bl.RecogerListadoCompletoRespuestasBL();
            preguntas = bl.RecogerListadoCompletoPreguntasBL();
            foreach(var pregunta in preguntas)
            {
                foreach (var respuesta in respuestas)
                {
                    List<clsRespuesta> r =new List<clsRespuesta>();

                    if(pregunta.IdPregunta == respuesta.IdPregunta)
                    {
                        r.Add(respuesta);
                    }
                    preguntasConRespuestas.Add(new clsPreguntaConRespuestas(pregunta, r));
                }

               
            }
        }


        public int EstablecerEstadoPaciente()
        {
            int i = 0;
            double maxVal = this.preguntas.Count * 0.7;
            foreach (var item in this.respuestas)
            {
                if(item.PosibleCaso)
                {
                    i++;
                }
            }
            if ((i) > maxVal)
            {
                this.usuario.Diagnostico = true;
            }
            return i;
        }
    }
}
