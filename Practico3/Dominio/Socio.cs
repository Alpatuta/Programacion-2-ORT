using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dominio
{
    public class Socio
    {
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private List<Deporte> _deportes = new List<Deporte>();
        private string _cedula;

        public string Cedula
        {
            get { return _cedula; }
        }

        public Socio(string nombre, string apellido, DateTime fechaNacimiento, /*List<Deporte> deportes*/ string cedula)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            //_deportes = deportes;
            _cedula = cedula;
        }

        public void ValidarDatosSocio()
        {
            if (string.IsNullOrEmpty(_nombre) || string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El nombre y apellido debe ser obligatorio");
            }

            if (string.IsNullOrEmpty(_cedula))
            {
                throw new Exception("La cedula debe ser obligatoria");
            }

            if (DateTime.Now.Year - _fechaNacimiento.Year < 18)
            {
                throw new Exception("El socio tiene que ser mayor de edad");
            }
        } 


    }
}
