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
        private int _cantDepositos;

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
            if (moneda.ToLower() == _tipoMoneda.ToLower())
            {
                if (_cantDepositos > 3)
                {
                    monto -= 100;
                }

                _saldoActual += monto;
                _cantDepositos++;
            }
        }

        public void Retiro(double monto)
        {
            if (monto > _saldoActual)
            {
                throw new Exception("Saldo insuficiente");
            }
            else
            {
                _saldoActual -= monto;
            }
        }
    }
}
