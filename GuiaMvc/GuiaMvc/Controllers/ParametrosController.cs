using Microsoft.AspNetCore.Mvc;

namespace GuiaMvc.Controllers
{
    public class ParametrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProbarParametro(int edad)
        {
            ViewBag.Mensaje01 = "Recibido el valor" + edad.ToString();
            return View("Index");
        }

        public IActionResult ProbarParametroConOtroNombre(int? edad)
        {
            if (edad != null)
            {
                ViewBag.Mensaje02 = "Recibido el valor " + edad.ToString();
            }
            else
            {
                ViewBag.Mensaje02 = "No se recibio ningun valor"; 
            }
            return View("Index");
        }
    }
}
