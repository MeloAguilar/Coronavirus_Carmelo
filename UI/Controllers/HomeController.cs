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
            return View(vm);
        }


        [HttpPost]
        public IActionResult Index(Index_VM vm)
        {
            IActionResult result = null;
            try
            {
                clsPersona usuario = new clsPersona();
                usuario.Diagnostico = false;
                int conteoPositivos = 0;
                foreach (var preguntas in vm.preguntasConRespuestas)
                {
                    foreach (var respuesta in preguntas.respuestas)
                    {
                        for (int i = 0; i < vm.respuestas.Count(); i++)
                        {
                            if (vm.respuestas.ElementAt(i).IdRespuesta == respuesta.IdRespuesta)
                            {
                                if (respuesta.PosibleCaso)
                                {
                                    conteoPositivos++;
                                }
                            }
                        }

                    }
                }

                if (conteoPositivos >= (vm.preguntas.Count*0.7))
                {
                    usuario.Diagnostico = true;
                }

                result = RedirectToAction("Diagnostico", usuario.Diagnostico);
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


        public IActionResult Diagnostico(bool diagnostico)
        {

            clsPersona usuario = new clsPersona();
            usuario.Diagnostico = diagnostico;
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Diagnostico(clsPersona usuario)
        {

            int filas = 0;
            var result = View("FinTest");
            try
            {
                filas = gestionBL.InsertarPersonaBL(usuario);
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
                else if (usuario.Diagnostico)
                {
                    ViewBag.MensajePositivo = "Su Diagnostico es Positivo";
                    ViewBag.FinTest = "Para más información sobre como Operar llame a uno de los siguientes números 900 400 061 / 955 545 060";

                }
                else if (!usuario.Diagnostico)
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