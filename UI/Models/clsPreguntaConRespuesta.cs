using BL.Listas;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class clsPreguntaConRespuesta : clsPregunta
    {
  
        public bool? PosibleCaso { get; set; }

        public clsPreguntaConRespuesta(int id, string pregunta) : base(id, pregunta)
        {
            PosibleCaso = null;
        }


        public clsPreguntaConRespuesta() { }

    }
}
