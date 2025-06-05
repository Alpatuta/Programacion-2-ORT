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
        private List<Cargo> _cargos = new List<Cargo>();

        public List<Cargo> Cargos
        {
            get { return _cargos; }
            
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public Categoria() { }

        public Categoria(int codigo, string descripcion)
        {
            _codigo = codigo;
            _descripcion = descripcion;
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
        /// <summary>
        /// Se utiliza desde el metodo Contains que se utiliza dentro del metodo que permita agregar 
        /// una nueva categoria
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Se utiliza desde Programa para imprimir los  datos de cada categoria
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _codigo + "-" + _descripcion;
        }
        /// <summary>
        /// Agrega el cargo a su lista de cargos - RF4
        /// </summary>
        /// <param name="cargo"></param>
        public void AgregarCargo(Cargo cargo)
        {
            //Voy a verificar que ya no este agregado
            if (!_cargos.Contains(cargo))
            {
                _cargos.Add(cargo);
            }
            else
            {
                throw new Exception("El cargo ya existe en la lista");
            }

        }
    }
}
