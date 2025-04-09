using LogicaNegocio;

namespace EjercicioTeoricoEmpleados
{
    internal class Program
    {
        private static Sistema miSistema=new Sistema();
        static void Main(string[] args)
        {
            /* CrearCategoria();
             CrearCategoria();
             MostrarCategorias();
             MostrarDatosCategoriasDos();*/
            CrearEmpleadoMensual();
            CrearEmpleadoJornalero();
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
    }
}
