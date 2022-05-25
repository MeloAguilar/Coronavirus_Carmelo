using BL.Gestion;
using BL.Listas;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        ListasCoronavirusBL listasBL = new ListasCoronavirusBL();
        GestionCoronavirusBL gestionBL = new GestionCoronavirusBL();

        public IActionResult Index()
        {
            Index_VM vm = new Index_VM();
            vm.usuario = new clsPersona();
            return View(vm);
        }


        [HttpPost]
        public IActionResult Index(Index_VM vm)
        {
            IActionResult result = null;
            foreach (var item in vm.respuestas)
            {
                item.establecerPosibleCaso();
            }
                try
                {
                    vm.EstablecerEstadoPaciente();

                    result = RedirectToAction("Diagnostico", vm.usuario);
                }
                catch (Exception e)
                {
                    result = View("Error");
                }
            return result;
        }
        public IActionResult Privacy()
        {

            return View();
        }


        public IActionResult Diagnostico(clsPersona p)
        {
            Diagnostico_VM vm = new Diagnostico_VM();
            vm.usuario = p;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Diagnostico(Diagnostico_VM vm)
        {

            int filas = 0;
            var result = View("FinTest");
            try
            {
                filas = gestionBL.InsertarPersonaBL(vm.usuario);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Un error sucedió mientras se añadía su usuario a nuestra base de datos. Por favor, intentelo de nuevo más tarde.";
                result = View("Error");
            }
            finally
            {
                if (filas == 0)
                {
                    ViewBag.Error = "Sus datos no se pudieron introducir en nuestra base de datos.";
                    result = View("Error");
                }
                else if (vm.usuario.Diagnostico)
                {
                    ViewBag.MensajePositivo = "Su Diagnostico es Positivo";
                    ViewBag.FinTest = "Para más información sobre como Operar llame a uno de los siguientes números 900 400 061 / 955 545 060";
                    
                }
                else if(!vm.usuario.Diagnostico)
                {
                    ViewBag.MensajePositivo = "Su Diagnostico es Negativo";
                    ViewBag.FinTest = "Recuerde llevar la mascarilla en todo momento y mantener la distancia de segguridad..." +
                        "Lo estamos haciendo genial.";

                }
            }
            return result;
        }

    }
}