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
            if (vm.respuestas[1].Respuesta == null)
            {
                result = View(vm);
            }
            else
            {
                try
                {
                    vm.EstablecerEstadoPaciente();

                    result = RedirectToAction("Diagnostico", vm);
                }
                catch (Exception e)
                {
                    result = View("Error");
                }
            }
            return result;
        }
        public IActionResult Privacy()
        {

            return View();
        }


        public IActionResult Diagnostico(Index_VM vm)
        {
            var result = View(vm.usuario);

            try
            {
                vm.usuario = new clsPersona();
            }
            catch (Exception e)
            {
                result = View("Error");
            }
            Diagnostico_VM vmD = new Diagnostico_VM();
            vmD.usuario = vm.usuario;
            vmD.respuestas = vm.respuestas;
            return View(vmD.usuario);
        }

        [HttpPost]
        public IActionResult Diagnostico(Diagnostico_VM vm)
        {

            int filas = 0;
            var result = View(vm.usuario);
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
                    result = View("FinTest");
                }
            }
            return result;
        }

    }
}