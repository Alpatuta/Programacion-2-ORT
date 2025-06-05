using Microsoft.AspNetCore.Mvc;

namespace GuiaMvc.Controllers
{
    public class BienvenidaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Saludo = "Hola coso";
            return View();
        }
    }
}
