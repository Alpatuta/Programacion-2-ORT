using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio
{
    public class DiaTrabajado:IValidar
    {
        private DateTime _fecha;
        private int _cantHoras;

        public int CantHoras
        {
            get { return _cantHoras; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
        }
        public DiaTrabajado(int cantHoras)
        {
            _fecha = DateTime.Now;
            _cantHoras = cantHoras;
        }

        public void Validar()
        {
            if (_fecha == DateTime.MinValue)
            {
                throw new Exception("La fecha es obligatoria");
            }
            if (_cantHoras <= 0)
            {
                throw new Exception("La cantidad de horas debe ser mayor a cero");
            }
        }
    }
}
