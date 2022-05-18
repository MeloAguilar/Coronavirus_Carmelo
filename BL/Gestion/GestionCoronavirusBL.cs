using DAL.Gestion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gestion
{
    public class GestionCoronavirusBL
    {
        GestionCoronavirus dal = new GestionCoronavirus();

        public int InsertarPersonaBL(clsPersona persona)
        {
            return dal.InsertarPersona(persona);
        }
    }
}
