using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    //Los dos puntos en la definicion de la clase indican herencia
    public class Jornalero:Empleado
    {
        private double _valorHora;
        private List<DiaTrabajado> _diasTrabajados = new List<DiaTrabajado>();

        public double ValorHora
        {
            get { return _valorHora; }
            set { _valorHora = value; }
        }

        /// <summary>
        /// Los dos puntos base indican que se llama al constructor de la clase padre en la relacion de herencia
        /// En este ejemplo la clase base es Empleado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="documento"></param>
        /// <param name="tipoDocumento"></param>
        /// <param name="fechaIngreso"></param>
        /// <param name="fechaAntiguedad"></param>
        /// <param name="valorHora"></param>
        public Jornalero(string nombre, string apellido, string documento, TipoDocumento tipoDocumento,
            DateTime fechaIngreso,DateTime fechaAntiguedad,double valorHora):
            base(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad)
        {
            _valorHora = valorHora;
        }
        public Jornalero() : base() { }
        public void Validar()
        {
            //Se llama al metodo Validar de Empleado 
            base.Validar();
            if (_valorHora <= 0)
            {
                throw new Exception("El valor hora debe ser mayor a cero");
            }
         
        }
        /// <summary>
        /// Si el empleado es Jornalero su salario se calcula multiplicando         /// 
        /// el valor hora por la cantidad de horas trabajadas en ese mes. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override double CalcularSalario(int mes)
        {
            double salario= _valorHora * CantidadHorasMes(mes);

            return CalcularSalarioFinal(salario);
        }

        private int CantidadHorasMes(int mes)
        {
            int cantHorasMes = 0;
            foreach(DiaTrabajado diaTrabajado in _diasTrabajados)
            {
                if (diaTrabajado.Fecha.Month == mes)
                {
                    cantHorasMes += diaTrabajado.CantHoras;
                }
                
            }
            return cantHorasMes;
        }
    }
}
