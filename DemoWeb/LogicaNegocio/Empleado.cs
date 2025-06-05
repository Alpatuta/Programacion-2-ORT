using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    //Esta clase no permite ser instanciada por eso se indica que es abstracta
    public abstract class Empleado:IComparable<Empleado>
    {
        private DateTime _fechaAntiguedad;
        private DateTime _fechaIngreso;
        private string _nombre;
        private string _documento;
        private TipoDocumento _tipoDocumento;
        private string _apellido;       
        private List<FechaCargo>_cargos=new List<FechaCargo>();
        private static int s_porcentajeBonificacion = 10;
        private int _mes;       
        public int Mes
        {
            set { _mes = value; }
        }

        public string Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

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
        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime FechaAntiguedad
        {
            get { return _fechaAntiguedad; }
            set { _fechaAntiguedad = value; }
        }

        public TipoDocumento TipoDeDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        public Empleado() { }

        public Empleado(string nombre, string apellido, string documento, TipoDocumento tipoDocumento,
            DateTime fechaIngreso,DateTime fechaAntiguedad)
        {
            _nombre = nombre;
            _apellido = apellido;
            _documento = documento;
            _tipoDocumento = tipoDocumento;
            _fechaAntiguedad = fechaAntiguedad;
            _fechaIngreso=fechaIngreso;
            _mes = DateTime.Now.Month;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El apellido es obligatorio");
            }
            if(string.IsNullOrEmpty(_documento))
            {
                throw new Exception("El documento es obligatorio");
            }
        
            if (_fechaIngreso == DateTime.MinValue)
            {
                throw new Exception("La fecha de ingreso no es correcta");
            }
            if (_fechaIngreso == DateTime.MinValue)
            {
                throw new Exception("La fecha de antiguedad no es correcta");
            }
            if (_fechaIngreso < _fechaAntiguedad)
            {
                throw new Exception("La fecha de antiguedad no puede ser menor a la fecha de ingreso");
            }
        }
        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if(obj!=null && obj is Empleado)
            {
                Empleado empleado = (Empleado)obj;
                sonIguales = _documento.Equals(empleado._documento);
            }
            return sonIguales;
        }

        /// <summary>
        /// Permite asigna un nuevo fecha cargo al empleado - RF 7
        /// </summary>
        /// <param name="cargo"></param>
        /// <exception cref="Exception"></exception>
        public void AgregarCargo(Cargo cargo)
        {
            FechaCargo cargoEmpleado = new FechaCargo(cargo);
            cargoEmpleado.Validar();
            if (!_cargos.Contains(cargoEmpleado))
            {
                 _cargos.Add(cargoEmpleado);
            }
            else
            {
                throw new Exception("Ya existe el cargo agregado para esa fecha");
            }
           
        }
        /// <summary>
        /// Se utiliza desde program para mostrar los datos del empleado 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _nombre + "-" + _apellido + "-" + _documento;
        }

        public abstract double CalcularSalario(int mes);

        protected double CalcularSalarioFinal(double salario)
        {
           
            if(DateTime.Now.Year - _fechaAntiguedad.Year > 5)
            {
                salario = salario + (salario * 100 / s_porcentajeBonificacion);
            }
            if(_cargos.Count > 1)
            {
                salario = salario * 1.2;
            }
            return salario;
        }

        public int CompareTo(Empleado? other)
        {
            return CalcularSalario(_mes).CompareTo(other.CalcularSalario(_mes)) * -1;
        }
    }
}
