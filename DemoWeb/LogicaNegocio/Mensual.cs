﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Mensual:Empleado
    {
        private double _sueldo;

        public double Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        public Mensual() : base() { }
        public Mensual(string nombre, string apellido, string documento, TipoDocumento tipoDocumento,
            DateTime fechaIngreso, DateTime fechaAntiguedad,double sueldo) 
            : base(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad)
        {
            _sueldo = sueldo;
        }

        public void Validar()
        {
            base.Validar();
            if (_sueldo <= 0)
            {
                throw new Exception("El sueldo debe ser mayor a cero");
            }
          
        }
        public override double CalcularSalario(int mes)
        {
            return CalcularSalarioFinal(_sueldo);
        }
    }
}
