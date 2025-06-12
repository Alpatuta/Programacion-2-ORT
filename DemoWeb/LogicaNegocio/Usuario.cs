using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario:IEquatable<Usuario>
    {
        public string NombreUsuario { get; set; }

        public string Contrasenia { get; set; }

        public string Rol { get; set; }

        public Usuario (string nombreUsuario, string contrasenia, string rol)
        {
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Rol = rol;
        }

        public Usuario() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreUsuario))
            {
                throw new Exception("El nombre de usuario no puede ser vacío");
            }

            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contraseña no puede ser vacía");
            }

            if (string.IsNullOrEmpty(Rol))
            {
                throw new Exception("El rol es obligatorio");
            }
        }

        public bool Equals(Usuario other)
        {
            return NombreUsuario.Equals(other.NombreUsuario);
        }
    }
}
