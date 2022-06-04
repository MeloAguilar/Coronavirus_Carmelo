using BL.Listas;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class clsPreguntaConRespuesta : clsPregunta
    {
        [Required(ErrorMessage = "Se deben contestar todas las preguntas")]
        public bool? PosibleCaso { get; set; }

        public clsPreguntaConRespuesta(int id, string pregunta) : base(id, pregunta)
        {
            PosibleCaso = null;
        }


        public clsPreguntaConRespuesta() { }

    }
}
