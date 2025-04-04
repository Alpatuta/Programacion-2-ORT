using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        private string _nombre;
        private string _paisOrigen;

        public string Nombre
        {
            get { return _nombre; }
        }

        public string PaisOrigen
        {
            get { return _paisOrigen; }
        }

        public Marca(string nombreMarca, string paisOrigen) 
        { 
            _nombre = nombreMarca;
            _paisOrigen = paisOrigen;
        }
    }
}
