using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        //Atributos 
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private decimal _valorHora;
        private int _antiguedad;
        private int _horasTrabajadas;

        //Propiedades
        public string Nombre
        {
            get { return this._nombre;}
            set { this._nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { this._fechaNacimiento = value; }
        }

        public decimal ValorHora
        {
            get { return _valorHora;}
            set { this._valorHora = value;}
        }

        public int Antiguedad
        {
            get { return _antiguedad; }
            set { this._antiguedad = value;}
        }

        public int HorasTrabajadas
        {
            get { return _horasTrabajadas; }
            set { this._horasTrabajadas = value; }
        }

        //Constructor
        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, decimal valorHora, int antiguedad, int horasTrabajadas)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNacimiento = fechaNacimiento;
            this._valorHora = valorHora;
            this._antiguedad = antiguedad;
            this._horasTrabajadas = horasTrabajadas;
        }

        private int CalcularSalario()
        {

        }

        private int CalcularLicencia()
        {

        }
    }
}
