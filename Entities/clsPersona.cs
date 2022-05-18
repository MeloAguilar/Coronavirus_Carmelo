using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class clsPersona
    {

        [Required(ErrorMessage = "El Dni es un campo obligatorio")]
        public int DniPersona { get; set; }

        [MaxLength(20), Required(ErrorMessage = "Debe introducir su nombre")]
        public string NombrePersona { get; set; }

        [MaxLength(50), Required(ErrorMessage = "Debe introducir sus apellidos")]
        public string  ApellidosPersona { get; set; }
        [MaxLength(12)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Direccion { get; set; }

        public bool Diagnostico { get; set; }
        public clsPersona() { }

        public clsPersona(int dniPersona, string nombrePersona, string apellidosPersona)
        {
            DniPersona=dniPersona;
            NombrePersona=nombrePersona;
            ApellidosPersona=apellidosPersona;
        }
    }
}