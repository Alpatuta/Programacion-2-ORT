using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio
{
    public class Cargo:IValidar
    {
        private int _codigo;
        private string _descripcion;
        private static int s_ultId=1;

        public string Descripcion
        {
            get { return _descripcion; }
        }
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Cargo() {
            _codigo = s_ultId++;
        }
        public Cargo(string descripcion)
        {          
            _descripcion = descripcion;
            _codigo = s_ultId++;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripción es obligatoria");
            }
        }
        /// <summary>
        /// Se usa desde el contains
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Cargo)
            {
                Cargo cargo = (Cargo)obj;
                sonIguales = _descripcion.Trim().ToUpper() == cargo._descripcion.Trim().ToUpper();
            }
            return sonIguales;
        }
        /// <summary>
        /// Se utiliza desde Program cuando se imprimen los datos de los cargos 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _codigo + " - " + _descripcion;  
        }


    }
}
