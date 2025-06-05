using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;
       
        public IActionResult Index()
        {
            try
            {
                //ViewBag.Empleados = miSistema.Empleados;
                //ViewBag.Empleados = new List<Empleado>();
                //ViewData["Empleados"] = miSistema.Empleados;
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View(miSistema.Empleados);
        }

      public IActionResult CreateJornalero()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateJornalero(Empleado empleado)
        {
            return View();
        }
       
    }
}
