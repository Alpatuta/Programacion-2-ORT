using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class DiaTrabajado
    {
        private DateTime _fecha;
        private int _cantHoras;

        public DiaTrabajado(int cantHoras)
        {
            _fecha = DateTime.Now;
            _cantHoras = cantHoras;
        }
<<<<<<< HEAD
=======

        public DateTime Fecha
        {
            get { return _fecha; }
        }

        public int CantidadHoras
        {
            get { return _cantHoras; }
        }
>>>>>>> 3c637846d6a9bcc188974af62da68f7982eff047
    }
}
