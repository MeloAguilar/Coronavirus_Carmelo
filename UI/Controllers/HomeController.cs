using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {


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
            try
            {
                vm.EstablecerEstadoPaciente();

                result = RedirectToAction("Diagnostico", vm);
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


        public IActionResult Diagnostico(Index_VM vm)
        {

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}