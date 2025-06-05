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
        public IActionResult CreateJornalero(Jornalero jornalero)
        {
            try
            {
                miSistema.AltaEmpleadoJornalero(jornalero);
                TempData["Mensaje"] = "Alta jornalero exitosa";
                return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
        

        public IActionResult CreateMensual()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateMensual(Mensual mensual)
        {
            try
            {
                miSistema.AltaEmpleadoMensual(mensual);
                TempData["Mensaje"] = "Alta mensual exitosa";
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }

        public IActionResult MostrarEmpleados()
        {
            return View();
        }

        [HttpPost]

        public IActionResult MostrarEmpleados(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Empleado> listaEmpleados = miSistema.EmpleadosFiltradoFechaIngreso(fechaDesde, fechaHasta);

            return View(listaEmpleados);
        }
    }
}
