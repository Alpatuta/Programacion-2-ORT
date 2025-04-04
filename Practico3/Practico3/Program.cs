using Dominio;
namespace Practico3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CrearCliente();
            //AgregarDepositoACuenta();
            //RetirarMonto();
            //CrearDeporte();
            //CrearSocio();
            Ejercicio2();
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

        //Ejercicio 2
        static void Ejercicio2()
        {
            try
            {
                Console.WriteLine("Ingrese marca");
                string marca = Console.ReadLine();

                Console.WriteLine("Ingrese su pais de origen");
                string pais = Console.ReadLine();

                Console.WriteLine("Ingrese modelo");
                string modelo = Console.ReadLine();

                Console.WriteLine("Matricula");
                string matricula = Console.ReadLine();

                Console.WriteLine("Ingrese si es usado o no. Datos validos (Si/No)");
                string usado = Console.ReadLine();
                bool esUsado = false;

                if(usado == "Si")
                {
                    esUsado = true;
                }

                Console.WriteLine("Ingrese el año");
                int.TryParse(Console.ReadLine(), out int anio);

                Console.WriteLine("Ingrese la fecha del ultimo servicio");
                DateTime.TryParse(Console.ReadLine(), out DateTime fecha);

                Auto auto = new Auto(modelo, matricula, anio, esUsado, fecha, marca, pais);
                auto.ValidarDatosAuto();

                Console.WriteLine(auto.ToString());


            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Ejercicio 3

        private static Sistema miSistema = new Sistema();
        static void CrearDeporte()
        {
            try
            {
                Console.WriteLine("Ingrese nombre del deporte");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese 1 si el deporte es grupal");
                int.TryParse(Console.ReadLine(), out int tipoDeporte);

                Console.WriteLine("Ingrese cantidad de profesores");
                int.TryParse(Console.ReadLine(), out int cantProfesores);

                bool esGrupal = false;

                if (tipoDeporte == 1)
                {
                    esGrupal = true;
                }

                Deporte deporte = new Deporte(nombre, esGrupal, cantProfesores);
                miSistema.AgregarDeporte(deporte);
                Console.WriteLine("Deporte agregado correctamente");

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CrearSocio()
        {
            try
            {
                Console.WriteLine("Ingrese su nombre");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese su apellido");
                string apellido = Console.ReadLine();

                Console.WriteLine("Ingrese su fecha de nacimiento");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);

                Console.WriteLine("Ingrese su cedula");
                string cedula = Console.ReadLine();

                Socio socio = new Socio(nombre, apellido,fechaNacimiento, cedula);

                miSistema.AgregarSocio(socio);

                Console.WriteLine("Socio creado correctamente");


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
