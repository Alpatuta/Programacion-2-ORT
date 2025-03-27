namespace Practico3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrearCliente();
        }

        //Ejercicio 1

        private static Cliente[] _cliente = new Cliente[2];
        public static void CrearCliente()
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
            _cliente[0] = cliente;
        }
    }
}
