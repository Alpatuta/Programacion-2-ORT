using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_2
{
    public class Auto
    {
        private string _marca;
        private string _modelo;
        private string _matricula;
        private bool _exoneraImpuestos;
        private int _anio;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public string Matricula
        {
            get { return _marca; }
            set { _matricula = value; }
        }

        public string ExoneraImpuestos
        {
            get 
            {
                if (_exoneraImpuestos)
                {
                    return "Si";
                }

                return "No";
            }
           
        }

        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public Auto (string marca, string modelo, string matricula, bool exoneraImpuestos, int anio)
        {
            _marca = marca;
            _modelo = modelo;
            _matricula = matricula;
            _exoneraImpuestos = exoneraImpuestos;
            _anio = anio;
        }

        public Auto() { }

        private void ValidarMatricula()
        {
            if (_matricula.Trim().Length != 7)
            {
                throw new Exception("Matricula invalida: el largo debe ser de 7 digitos");
            }
        }

        private void ValidarMarca()
        {
            if (_marca.Length < 3)
            {
                throw new Exception("Marca invalida: la marca debe tener 3 letras");
            }
        }

        public void Validar()
        {
            ValidarMatricula();
            ValidarMarca();
        } 

        private int CalcularPatente()
        {
            int patente = 0;

            if (_anio <= 2015 && _exoneraImpuestos)
            {
                patente = 10000;
            }else if (_anio <= 2015 && !_exoneraImpuestos)
            {
                patente = 12000;
            }
            else
            {
                patente = 17000;
            }

            return patente;
        }

        public string DevolverDatos()
        {
            return $"Marca: {_marca} \n" + 
                $"Modelo: {_modelo} \n" + 
                $"Matricula: {_matricula} \n" + 
                $"Exonera impuestos: {ExoneraImpuestos} \n" +
                $"Año: {_anio} \n" + 
                $"Patente: {CalcularPatente()}";
        }


    }
}
