using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico3
{
     public class Cliente
     {
        private string _nombre;
        private string _apellido;
        private string _documento;
        private CuentaCorriente _cuentaCorriente;

        public string Documento
        {
            get { return _documento; }
       
        }

        public Cliente(string nombre, string apellido, string documento, int nroCuenta, string tipoMoneda)
        {
            _nombre = nombre;
            _apellido = apellido;
            _documento = documento;
            _cuentaCorriente = new CuentaCorriente(nroCuenta, tipoMoneda);
        }

        public void DespositarEnCuenta(double monto, string tipoMoneda)
        {
            _cuentaCorriente.Deposito(monto, tipoMoneda);
        }

        public void RetirarMontoCuenta(double monto)
        {
            _cuentaCorriente.Retiro(monto);
        }
     
     }
}
