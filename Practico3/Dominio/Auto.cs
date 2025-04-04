using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Auto
    {
        private string _modelo;
        private string _matricula;
        private int _anio;
        private bool _esUsado;
        private DateTime _fechaUltimoServicio;
        private Marca _marca;

        public string EsUsado
        {
            get
            {
                if(_esUsado)
                {
                    return "Si";
                }

                return "No";
            }
        }

        public Auto(string modelo, string matricula, int anio, bool esUsado, DateTime fechaUltimoServicio, string nombreMarca, string paisOrigen) 
        { 
            _modelo = modelo;
            _matricula = matricula;
            _anio = anio;
            _esUsado = esUsado;
            _fechaUltimoServicio = fechaUltimoServicio;
            _marca = new Marca(nombreMarca, paisOrigen);
        }

        public void ValidarDatosAuto()
        {
            if(string.IsNullOrEmpty(_modelo) || string.IsNullOrEmpty(_matricula))
            {
                throw new Exception("Modelo y matricula deben ser obligatorios");
            }

            if(_anio < 1950)
            {
                throw new Exception("Año de auto invalido");
            }
        }

        public DateTime ProximoServicio(DateTime fechaUltimoServicio)
        {
            DateTime fechaProximoServicio = fechaUltimoServicio.AddYears(1);

            
            return fechaProximoServicio;
        }

        public string ToString()
        {
            return $"Marca: {_marca.Nombre} \n " + 
                   $"Pais de origen: {_marca.PaisOrigen} \n"+
                   $"Modelo: {_modelo} \n" +
                   $"Matricula: {_matricula} \n" +
                   $"Es usado: {EsUsado} \n" +
                   $"Año: {_anio} \n" +
                   $"Fecha de ultimo servicio: {_fechaUltimoServicio} \n"+
                   $"Fecha proximo servicio: {ProximoServicio(_fechaUltimoServicio)}"
                   ;
        }
        
    }
}
