using LogicaNegocio;

namespace EjercicioTeoricoEmpleados
{
    internal class Program
    {
        private static Sistema miSistema=new Sistema();
        static void Main(string[] args)
        {

            int opcion = -1;

             while (opcion != 0)
             {
                Menu();
                Console.WriteLine("Ingrese opcion de menú");
                int.TryParse(Console.ReadLine(), out opcion);
                EvaluarOpcion(opcion);
             }
            Console.ReadKey();

        }

        static void Menu()
        {
            Console.WriteLine("1- Alta Categoria");
            Console.WriteLine("2- Alta Mensula");
            Console.WriteLine("3- Alta Jornalero");
            Console.WriteLine("4- Alta Cargo");
            Console.WriteLine("0- Salir");
        }

        static void EvaluarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    CrearCategoria();
                    break;
                case 2:
                    CrearEmpleadoMensual();
                    break;
                case 3:
                    CrearEmpleadoJornalero();
                    break;
                case 4:
                    CrearCargo();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        static void CrearCategoria()
        {
            Console.WriteLine("Ingrese codigo");
            int.TryParse(Console.ReadLine(), out int codigo);
            Console.WriteLine("Ingrese descripción");
            string descripcion = Console.ReadLine();
            if (!string.IsNullOrEmpty(descripcion))
            {
                Categoria categoria = new Categoria(codigo, descripcion);
                miSistema.AltaCategoria(categoria);
            }
        }

        static void MostrarCategorias()
        {
            Console.WriteLine(miSistema.DatosCategorias());
        }
        //Opcion 2
        static void MostrarDatosCategoriasDos()
        {
            foreach(Categoria categoria in miSistema.Categorias)
            {
                Console.WriteLine(categoria);
            }
        }
        static void CrearEmpleadoMensual()
        {
            string nombre = "Liliana";
            string apellido = "Pino";
            string documento = "111111";
            TipoDocumento tipoDocumento = TipoDocumento.Cedula;
            DateTime fechaIngreso = new DateTime(2020, 12, 12);
            DateTime fechaAntiguedad = new DateTime(2008, 12, 12);
            double sueldo = 50000;
            Mensual mensual = new Mensual(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad, sueldo);
            miSistema.AltaEmpleadoMensual(mensual);
        }
        static void CrearEmpleadoJornalero()
        {
            string nombre = "Liliana";
            string apellido = "Pino";
            string documento = "111111";
            TipoDocumento tipoDocumento = TipoDocumento.Cedula;
            DateTime fechaIngreso = new DateTime(2021, 12, 12);
            DateTime fechaAntiguedad = new DateTime(2009, 12, 12);
            double valorHora = 1000;
            Jornalero jornalero = new Jornalero(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad, valorHora);
            miSistema.AltaEmpleadoJornalero(jornalero);
        }

        static void CrearCargo()
        {
            try
            {
                Console.WriteLine("Ingrese la descripcion");
                string descripcion = Console.ReadLine();

                if (!string.IsNullOrEmpty(descripcion))
                {
                    Cargo cargo = new Cargo(descripcion);
                    miSistema.AltaCargo(cargo);
                    Console.WriteLine("Cargo creado con exito");
                }
                else
                {
                    Console.WriteLine("La descripcion es obligatoria");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
