using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cargo
    {
        private int _codigo;
        private string _descripcion;
        private static int s_ultimoCodigo = 1;

        public Cargo(string descripcion)
        {
            _descripcion = descripcion;
            _codigo = s_ultimoCodigo ++;

        }

        public void ValidarCargo()
        {
            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripcion no puede ser vacia");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Cargo)
            {
                Cargo cargo = (Cargo)obj;
                if (cargo._descripcion.Trim().ToLower() == _descripcion.Trim().ToLower())
                {
                    sonIguales = true;
                }
            }

            return sonIguales;
        }

        public override string ToString()
        {
            return $"Codigo cargo: {_codigo} \n" + 
                   $"Descripcion cargo: {_descripcion}";
        }

    }

   
}
