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
        private static int _precio = 300;
        private bool _esUrgente;

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
            int precio = _precio;

            if (_esUrgente)
            {
                precio *= 2;
            }

            return precio;
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
