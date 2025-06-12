using System.Diagnostics;
using DemoWeb.Models;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Usuario usuario)
        {
            try
            {
                string rol = Sistema.Instancia.Login(usuario.NombreUsuario, usuario.Contrasenia);
                if (!string.IsNullOrEmpty(rol))
                {
                    HttpContext.Session.SetString("rol", rol);
                    if (rol.Equals("Administrador"))
                    {
                        return RedirectToAction("Create", "Cargo");
                    }
                    if (rol.Equals("Gerente"))
                    {
                        return RedirectToAction("MostrarEmpleados", "Empleado");
                    }
                    
                }
                else
                {
                    ViewBag.Mensaje = "Crendenciales incorrectas";
                }

            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
