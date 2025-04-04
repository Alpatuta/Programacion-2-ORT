using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Deporte
    {
        private string _nombre;
        private bool _esGrupal;
        private int _cantProfes;

        public string Nombre
        {
            get { return _nombre; }
        }

        public Deporte(string nombre, bool esGrupal, int cantProfes)
        {
            _nombre = nombre;
            _esGrupal = esGrupal;
            _cantProfes = cantProfes;
        }

       public void ValidarDatos()
       {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (_cantProfes <= 0)
            {
                throw new Exception("La cantidad de profesores debe ser mayor a cero");
            }
       }
    }
}
