using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FechaCargo
    {
        private DateTime _fecha;
        private Cargo _cargo;

        public FechaCargo(Cargo cargo)
        {
            _fecha = DateTime.Now;
            _cargo = cargo;
        }
        public void Validar()
        {
            if (_cargo == null)
            {
                throw new Exception("El cargo es obligatorio");
            }
        }
        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj !=null && obj is Cargo) {
                FechaCargo fecha =(FechaCargo)obj;
                sonIguales=fecha._cargo==_cargo && fecha._fecha==_fecha;
            }
            return sonIguales;
        }
    }
}
