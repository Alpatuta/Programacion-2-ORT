namespace Practico3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CrearCliente();
            //AgregarDepositoACuenta();
            //RetirarMonto();
        }

        //Ejercicio 1

        private static Cliente[] _clientes = new Cliente[2];
        static void CrearCliente()
        {
            Console.WriteLine("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese documento: ");
            string documento = Console.ReadLine();

            Console.WriteLine("Ingrese el numero de cuenta");
            int.TryParse(Console.ReadLine(), out int numeroCuenta);

            Console.WriteLine("Ingrese el tipo de moneda. Tipos validos: \n UYU: pesos uruguayos \n USD: dolares \n ARS: pesos argentinos");
            string tipoMoneda = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, apellido, documento, numeroCuenta, tipoMoneda);
            _clientes[0] = cliente;
        }

        static void AgregarDepositoACuenta()
        {
            Console.WriteLine("Ingrese documento: ");
            string documento = Console.ReadLine();

            Console.WriteLine("Ingrese monto a depositar: ");
            double.TryParse(Console.ReadLine(), out double monto);

            Console.WriteLine("Ingrese el tipo de moneda. Tipos validos: \n UYU: pesos uruguayos \n USD: dolares \n ARS: pesos argentinos");
            string tipoMoneda = Console.ReadLine();

            Cliente clienteBuscado = BuscarCliente(documento);
            clienteBuscado.DespositarEnCuenta(monto, tipoMoneda);
        }


        static void RetirarMonto()
        {
            try
            {
                Console.WriteLine("Ingrese documento: ");
                string documento = Console.ReadLine();

                Console.WriteLine("Ingrese monto a depositar: ");
                double.TryParse(Console.ReadLine(), out double monto);

                Cliente clienteBuscado = BuscarCliente(documento);
                clienteBuscado.RetirarMontoCuenta(monto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static Cliente BuscarCliente(string cedula)
        {
            Cliente clienteBuscado = null;

            int i = 0;

            while (i < _clientes.Length && clienteBuscado == null)
            {
                if (_clientes[i] != null && _clientes[i].Documento == cedula)
                {
                    clienteBuscado = _clientes[i];
                }

                i++;
            }

            return clienteBuscado;
        }

        //Ejercicio 3

    }
}
