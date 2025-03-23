using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_2
{
    public class CitaMedica
    {
        private int _id;
        private DateTime _fecha;
        private string _lugar;
        private string _cedula;
        private int _precio = 300;
        private bool _esUrgente;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Lugar
        {
            get { return _lugar; }
            set { _lugar = value; }
        }

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public string EsUrgente
        {
            get
            {
                if (_esUrgente)
                {
                    return "Si";
                }

                return "No";
            }
        }

        public CitaMedica(int id, DateTime fecha, string lugar, string cedula, bool esUrgente) 
        {
            _id = id;
            _fecha = fecha;
            _lugar = lugar;
            _cedula = cedula;
            _esUrgente = esUrgente;
        }

        public CitaMedica() { }

        private int CalcularCitaMedica()
        {

            if (_esUrgente)
            {
                _precio *= 2;
            }
            else
            {
                _precio *= 1;
            }

            return _precio;
        }

        public string MostrarDatos()
        {
            return $"Id: {_id} \n" +
                $"Fecha de consulta: {_fecha} \n" +
                $"Lugar: {_lugar} \n" +
                $"Cedula: {_cedula} \n" +
                $"Es urgente: {EsUrgente} \n" +
                $"Costo final: {CalcularCitaMedica()}";
        }
    }
}
