using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
    { 
        private string _numeroVuelo;
        private Frecuencia _frecuencia;
        private Ruta _ruta;
        private Avion _avion;

        public Vuelo (string numeroVuelo, Frecuencia frecuencia, Ruta ruta, Avion avion)
        {
            _numeroVuelo = numeroVuelo;
            _frecuencia = frecuencia;
            _ruta = ruta;
            _avion = avion;
        }

        public string NumeroVuelo { get { return _numeroVuelo; } }

        public void ValidarVuelo()
        {
            if (string.IsNullOrEmpty(_numeroVuelo))
            {
                throw new Exception("El numero de vuelo no puede ser vacio");
            }

            if (_ruta == null)
            {
                throw new Exception("El vuelo debe tener asignada una ruta");
            }

            if (_avion == null)
            {
                throw new Exception("El vuelo debe tener un avion asignado");
            }

            if (_avion.Alcance < _ruta.Distancia)
            {
                throw new Exception("El alcance del avion tiene que ser mayor o igual a la distancia de la ruta");
            }

            if((int)_frecuencia < 0 || (int)_frecuencia > 6)
            {
                throw new Exception("La frecuencia no es valida");
            }
        }

        public override bool Equals(object? obj)
        {
            bool existe = false;

            if(obj != null &&  obj is Vuelo)
            {
                Vuelo vuelo = (Vuelo)obj;
                existe = vuelo._numeroVuelo == _numeroVuelo;
            }
            
            return existe;
        }

        public bool PerteneceRuta(string codigoIata)
        {
            return _ruta.estaEnLaRuta(codigoIata);
        }

        public override string ToString()
        {
            return $"{_numeroVuelo} - {_avion.Modelo} - {_ruta.infoCodigoIata()} - {_frecuencia} \n ";
        }
    }
}
