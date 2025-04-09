using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Jornalero:Empleado
    {
        private double _valorHora;
        private List<DiaTrabajado> _diasTrabajados = new List<DiaTrabajado>();

        public Jornalero(string nombre, string apellido, string documento, TipoDocumento tipoDocumento,
            DateTime fechaIngreso,DateTime fechaAntiguedad,double valorHora):
            base(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad)
        {
            _valorHora = valorHora;
        }
        public void Validar()
        {
            base.Validar();
            if (_valorHora <= 0)
            {
                throw new Exception("El valor hora debe ser mayor a cero");
            }
         
        }
    }
}
