using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Empleado
    {
        private DateTime _fechaAntiguedad;
        private DateTime _fechaIngreso;
        private string _nombre;
        private string _documento;
        private TipoDocumento _tipoDocumento;
        private string _apellido;       
        private List<FechaCargo>_cargos=new List<FechaCargo>();

        /*public string Nombre
        {
            get { return _nombre; }
        }*/

        public Empleado(string nombre, string apellido, string documento, TipoDocumento tipoDocumento,
            DateTime fechaIngreso,DateTime fechaAntiguedad)
        {
            _nombre = nombre;
            _apellido = apellido;
            _documento = documento;
            _tipoDocumento = tipoDocumento;
            _fechaAntiguedad = fechaAntiguedad;
            _fechaIngreso=fechaIngreso;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
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


    }
}
