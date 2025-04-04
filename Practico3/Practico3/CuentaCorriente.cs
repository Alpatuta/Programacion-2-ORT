using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico3
{
    public class CuentaCorriente
    {
        private int _nroCuenta;
        private string _tipoMoneda;
        private double _saldoActual;

        public CuentaCorriente(int nroCuenta, string tipoMoneda)
        {
            _nroCuenta = nroCuenta;
            _tipoMoneda = tipoMoneda;
         
        }

        public double SaldoActual
        {
            get { return _saldoActual; }
            set { _saldoActual = value; }
        } 

        //public string validarTipoMoneda(){}
        
        public void Deposito(double monto, string moneda)
        {
            if (moneda == _tipoMoneda)
            {
                _saldoActual += monto;
            }
        }

        private void Retiro(double monto)
        {

        }
    }
}
