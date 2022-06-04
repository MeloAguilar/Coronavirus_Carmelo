using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class clsPersona
    {

        [Required(ErrorMessage = "El Dni es un campo obligatorio"), DisplayName("DNI")]
        public string DniPersona { get; set; }

        [MaxLength(20), Required(ErrorMessage = "Debe introducir su nombre"), DisplayName("Nombre")]
        public string NombrePersona { get; set; }

        [MaxLength(50), Required(ErrorMessage = "Debe introducir sus apellidos"), DisplayName("Apellidos")]
        public string  ApellidosPersona { get; set; }
        [MaxLength(12), Required(ErrorMessage = "Tu número de telefono es imprescindible para contactar contigo")]
        public string Telefono { get; set; }

        [MaxLength(100), Required(ErrorMessage = "Debes introducir tu dirección.")]
        public string Direccion { get; set; }

        public bool Diagnostico { get; set; }
        public clsPersona() { }

        public clsPersona(string dniPersona, string nombrePersona, string apellidosPersona)
        {
            DniPersona=dniPersona;
            NombrePersona=nombrePersona;
            ApellidosPersona=apellidosPersona;
            Diagnostico = false;
        }
    }
}