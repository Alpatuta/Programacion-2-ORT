using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace DemoWeb.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
           
            return View(Sistema.Instancia.Categorias);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            try
            {
                Sistema.Instancia.AltaCategoria(categoria);
                TempData["Mensaje"] = "Alta exitosa";
                return RedirectToAction(nameof(Index));
              
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
        public IActionResult AsignarCargo(int codigo)
        {
            IEnumerable<Cargo> cargos = null;
            try
            {
                if (codigo > 0)
                {
                    cargos = Sistema.Instancia.Cargos;
                }
                else
                {
                    ViewBag.Mensaje = "El código recibido no es correcto";
                }
            }catch(Exception ex) {
                ViewBag.Mensaje = "Error";
            }
            return View(cargos);
        }
        [HttpPost]
        public IActionResult AsignarCargoACategoria(int codigo,Cargo cargo)
        {
            try
            {
                if (codigo > 0 && cargo!=null )
                {
                    Sistema.Instancia.AsignarCargoACategoria(codigo, cargo);
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult MostrarCargosPorCategoria()
        {
            return View();
        }

        [HttpPost]

        public IActionResult MostrarCargosPorCategoria(int codigoCategoria)
        {
            List<Cargo> listaCargos = Sistema.Instancia.CargosDeCategoria(codigoCategoria);

            return View(listaCargos);
        }
    }
}
