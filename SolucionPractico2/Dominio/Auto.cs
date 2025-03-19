using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Auto
    {
        //Atributos
        private string _marca;
        private string _modelo;
        private bool _exoneraImpuestos;
        private string _matricula;
        private int _anio;

        //Propiedades
        public string Marca
        {
            get { return this._marca; }
            set { this._marca = value; }
        }

        public string Modelo
        {
            get { return this._modelo; }
            set { this._modelo = value; }
        }

        public bool ExoneraImpuestos
        {
            get { return this._exoneraImpuestos; }
            set { this._exoneraImpuestos = value; }
        }

        public string Matricula
        {
            get { return this._matricula; }
            set { this._matricula = value; }
        }

        public int Anio
        {
            get { return this._anio; }
            set { this._anio = value; }
        }

        //Constructor
        public Auto(string marca, string modelo, bool exoneraImpuestos, string matricula, int anio)
        {
            this._marca = marca;
            this._modelo = modelo;
            this._exoneraImpuestos = exoneraImpuestos;
            this._matricula = matricula;
            this._anio = anio;
        }

        //Metodos
        private void ValidarMatricula()
        {
            if (this._matricula.Length != 7)
            {
                throw new Exception("Matricula invalida: el largo debe ser de 7 caracteres");
            }
        }

        private void ValidarMarca()
        {
            if(this._marca.Length < 3)
            {
                throw new Exception("Marca invalida: debe tener minimo 3 letras");
            }
        }

        public void Validar()
        {
            ValidarMatricula();
        }

        public int CalcularPatente()
        {
            int pantenteFinal = 0;

            if (this._anio <= 2015 && this._exoneraImpuestos)
            {
                pantenteFinal = 10000;

            } else if (this._anio <= 2015 && !this._exoneraImpuestos)
            {

                pantenteFinal = 12000;

            }
            else
            {
                pantenteFinal = 15000;
            }

            return pantenteFinal;
        }

        public override string ToString()
        {
            return $"Marca: {_marca} \n" +
                $"Modelo: {_modelo} \n" +
                $"Exonera impuestos: {_exoneraImpuestos} \n" +
                $"Matricula: {_matricula} \n" +
                $"Año {_anio} \n";
        }
    }
}
