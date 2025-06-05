using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class CargoController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;

        public ActionResult Index()
        {
            IEnumerable<Cargo> cargos = new List<Cargo>();
            try
            {
                 cargos=miSistema.Cargos;
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View(cargos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string descripcion)
        {
            try
            {
                miSistema.AltaCargo(new Cargo(descripcion));
                ViewBag.Mensaje = "Alta exitosa";
                
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
       
    }
}
