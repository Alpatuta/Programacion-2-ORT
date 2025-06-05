using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje
    {
        private int _idPasaje;
        private static int s_ultimoId;
        private Vuelo _vuelo;
        private DateTime _fecha;
        private Cliente _pasajero;
        private Equipaje _equipaje;
        private int _precio;

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
        {
            _idPasaje = s_ultimoId ++;
            _vuelo = vuelo;
            _fecha = fecha;
            _pasajero = pasajero;
            _equipaje = equipaje;
        }

        public int IdPasaje { get { return _idPasaje; } }

        public DateTime Fecha { get { return _fecha; } }

        public void ValidarPasaje()
        {
            if (_pasajero == null)
            {
                throw new Exception("El pasaje tiene que tener asigando un pasajero");
            }

            if(_vuelo == null)
            {
                throw new Exception("El pasaje tiene que tener un vuelo asignado");
            }

            if(_fecha == DateTime.MinValue)
            {
                throw new Exception("Ingresar una fecha");
            }

            if(_equipaje != Equipaje.Light && _equipaje != Equipaje.Cabina && _equipaje != Equipaje.Bodega)
            {
                throw new Exception("Ingrese el tipo de equipaje");
            }

        }

        public override bool Equals(object? obj)
        {
            bool existe = false;

            if(obj != null && obj is Pasaje)
            {
                Pasaje pasaje = (Pasaje)obj;
                existe = pasaje._idPasaje == _idPasaje;
            }

            return existe;
        }

        public override string ToString()
        {
            return $"{_idPasaje} - {_pasajero.Nombre} - {_precio} - {_fecha} - {_vuelo.NumeroVuelo} \n";
        }
    }
}
