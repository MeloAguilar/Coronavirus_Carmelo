using Entities;

namespace UI.Models
{
    public class Diagnostico_VM
    {
        public clsPersona usuario { get; set; }

        public List<clsRespuesta> respuestas { get; set; }

        public Diagnostico_VM() { }
    }
}
