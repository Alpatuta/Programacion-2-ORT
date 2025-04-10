using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Categoria
    {
        private int _codigo;
        private string _descripcion;
      //private Cargo _cargo; 

        public Categoria(int codigo, string descripcion /*Cargo cargo*/)
        {
            _codigo = codigo;
            _descripcion = descripcion;
          //_cargo = cargo;
        }   

        public void Validar()
        {
            if (_codigo <= 0)
            {
                throw new Exception("El código debe ser mayor a cero");
            }
            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripción es obligatoria");
            }
        }
        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if(obj!=null && obj is Categoria)
            {
                //Casteo
                Categoria categoria = (Categoria)obj;
                sonIguales = _codigo == categoria._codigo;
            }
            return sonIguales;
        }
        public override string ToString()
        {
            return _codigo + "-" + _descripcion;
        }
    }
}
