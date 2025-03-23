using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_2
{
    public class Empleado
    {
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private int _valorHora;
        private int _aniosAntiguedad;
        private int _cantHoras;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }  
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int ValorHora
        {
            get { return _valorHora; }
            set { _valorHora = value; }
        }

        public int AniosAntiguedad
        {
            get { return _aniosAntiguedad; }
            set { _aniosAntiguedad = value;}
        }

        public int CantHoras
        {
            get { return _cantHoras;}
            set { _cantHoras = value; } 
        }

        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, int valorHora, int aniosAntiguedad, int cantHoras)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _valorHora = valorHora;
            _aniosAntiguedad = aniosAntiguedad;
            _cantHoras = cantHoras;
        }

        public Empleado() { }

        private int CalcularSalario()
        {
            int salarioFinal = 0;

            salarioFinal = _valorHora * _cantHoras;

            return salarioFinal;
        }

        private int CalcularLicencia()
        {
            int diasLicencia = 20;

            if(_aniosAntiguedad > 10)
            {
                diasLicencia = 25;
            }else if (_aniosAntiguedad > 5 && _aniosAntiguedad <= 9)
            {
                diasLicencia = 21;
            }

            return diasLicencia;
        }

        public void Calcular()
        {
            CalcularSalario();
            CalcularLicencia();
        }

        public string DevolverDatos()
        {
            return $"Nombre: {_nombre} \n" +
                $"Apellido: {_apellido} \n" + 
                $"Fecha de nacimiento: {_fechaNacimiento} \n" +
                $"Valor por hora: {_valorHora} \n" +
                $"Años de antiguedad: {_aniosAntiguedad} \n" +
                $"Cantidad de horas trabajadas: {_cantHoras} \n" +
                $"Salario: {CalcularSalario()} \n" +
                $"Dias de licencia: {CalcularLicencia()}";
        }


    }
}
