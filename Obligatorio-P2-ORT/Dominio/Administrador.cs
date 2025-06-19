using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador:Usuario
    {
        private string _apodo;

        public Administrador(string correoElectronico, string contrasenia, string apodo) 
            : base (correoElectronico, contrasenia)
        {
            _apodo = apodo;
        }

        public void ValidarAdmin()
        {
            base.ValidarUsuario();

            if(string.IsNullOrEmpty(_apodo))
            {
                throw new Exception("El apodo no puede ser vacio");
            }
        }
    }
}
