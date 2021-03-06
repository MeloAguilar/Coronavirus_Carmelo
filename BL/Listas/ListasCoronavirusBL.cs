using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Listas;

namespace BL.Listas
{
    public class ListasCoronavirusBL
    {
        ListasCoronavirus dal = new ListasCoronavirus();
        public List<clsPregunta> RecogerListadoCompletoPreguntasBL()
        {
            return dal.RecogerListadoCompletoPreguntas();
        }

        public List<clsRespuesta> RecogerListadoCompletoRespuestasBL()
        {
            return dal.RecogerListadoCompletoRespuestas();
        }


        public List<clsRespuesta> ListadoDeRespuestasPorIdPreguntaBL(int id)
        {
            return dal.ListadoDeRespuestasPorIdPregunta(id);
        }
    }
}
