using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente:Usuario
    {
        private string _nombre;
        private string _documento;
        private string _nacionalidad;

        public Cliente(string correoElectronico, string contrasenia, string nombre, string documento, string nacionalidad)
            : base (correoElectronico, contrasenia)
        {
            _nombre = nombre;
            _documento = documento;
            _nacionalidad = nacionalidad;
        }

        public string Cedula { get  { return _documento; } }

        public string Nombre { get { return _nombre; } }

        public void ValidarCliente()
        {
            base.ValidarUsuario();

            if (_documento.Length != 8)
            {
                throw new Exception("El documento tiene que ser de 8 digitos");
            }
        }

        public bool EsOcasional(Cliente cliente, string documento)
        {
            bool esOcasional = false;
            if (cliente._documento == documento)
            {
                esOcasional = true;
            }

            return esOcasional;
        }

        public override string ToString()
        {
            return _nombre + " - " + base.ToString() + _nacionalidad;
        }
    }
}
