using BL.Listas;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models.ViewModels
{
    public class Index_VM
    {
        private ListasCoronavirusBL bl = new ListasCoronavirusBL();
   

        public List<clsRespuesta> respuestas { get; }


        public List<clsPreguntaConRespuesta> PreguntasConRespuesta { get; set; }

        public Index_VM()
        {

            respuestas = bl.RecogerListadoCompletoRespuestasBL();
            PreguntasConRespuesta = new List<clsPreguntaConRespuesta>();
            foreach(var pregunta in bl.RecogerListadoCompletoPreguntasBL())
            { 
                
                PreguntasConRespuesta.Add(new clsPreguntaConRespuesta(pregunta.IdPregunta, pregunta.Pregunta));

            }
        }



    }
}
