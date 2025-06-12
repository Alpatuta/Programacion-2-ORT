using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Tarea:IEquatable<Tarea>
    {
        public string Descripcion { get; set; }

        public int Codigo { get; set; }

        private static int s_ultId = 1;

        public Usuario UsuarioLogueado { get; set; }

        public Tarea (string descripcion, Usuario usuarioLogueado)
        {
            Descripcion = descripcion;
            Codigo = s_ultId ++;
            UsuarioLogueado = usuarioLogueado;
        }

        public Tarea() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcón debe ser obligatoria");
            }

            if(UsuarioLogueado == null)
            {
                throw new Exception("La tarea tiene que tener un usuario asignado");
            }
        }

        public bool Equals(Tarea other)
        {
            return Descripcion.Equals(other.Descripcion);
        }
    }
}
