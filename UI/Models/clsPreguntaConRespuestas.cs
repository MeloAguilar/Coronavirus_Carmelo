using Entities;

namespace UI.Models
{
    public class clsPreguntaConRespuestas
    {
        public clsPregunta pregunta { get; set; }

        public List<clsRespuesta> respuestas { get; set; }

        public clsPreguntaConRespuestas(clsPregunta p, List<clsRespuesta> r)
        {
            pregunta = p;
            respuestas = r;
        }

        public clsPreguntaConRespuestas(clsPregunta p)
        {
            pregunta = p;
            respuestas = new List<clsRespuesta>();
        }

        public clsPreguntaConRespuestas() { }

    }
}
