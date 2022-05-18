using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsPregunta
    {
        public int IdPregunta { get; }

        public string Pregunta { get; }


        public clsPregunta(int id, string pregunta)
        {
            IdPregunta = id;
            Pregunta = pregunta;
        }
    }
}
