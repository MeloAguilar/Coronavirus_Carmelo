using BL.Listas;
using Entities;

namespace UI.Models
{
    public class Index_VM
    {
        private ListasCoronavirusBL bl = new ListasCoronavirusBL();
        public List<clsPregunta> preguntas { get; }

        public List<clsRespuesta> respuestas { get; set; }

        public clsPersona usuario { get; set; }


        public Index_VM()
        {
            respuestas =new List<clsRespuesta>();
            preguntas = bl.RecogerListadoCompletoPreguntasBL();
            foreach(var pregunta in preguntas)
            {
                
                respuestas.Add(new clsRespuesta(pregunta.IdPregunta));
            }
        }


        public int EstablecerEstadoPaciente()
        {
            int i = 0;
            double maxVal = this.preguntas.Count * 0.7;
            foreach (var item in this.respuestas)
            {
                if(!(item.Respuesta.Equals("No") ||  item.Respuesta.Equals("Entre 37º y 38º")))
                {
                    i++;
                }
            }
            if ((i / this.preguntas.Count) > maxVal)
            {
                this.usuario.Diagnostico = true;
            }
            return i;
        }
    }
}
