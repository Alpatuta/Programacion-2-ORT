using LogicaNegocio;
using System.ComponentModel.Design;

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
                Console.WriteLine("Ingrese opción de menú");
                int.TryParse(Console.ReadLine(), out opcion);
                EvaluarOpcion(opcion);
            }
            Console.ReadKey();
        }
        static void Menu()
        {
            Console.WriteLine("1-Alta Categoría");
            Console.WriteLine("2-Alta Mensual");
            Console.WriteLine("3-Alta Jornalero");
            Console.WriteLine("4-Alta Cargo");
            Console.WriteLine("5-Mostrar cargos por categoria");
            Console.WriteLine("6-Mostrar empleados por fechas");
            Console.WriteLine("7-Asignar cargo a empleado");
            Console.WriteLine("0-Salir");
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
                case 5:
                    MostrarCargosDeCategoria();
                    break;
                case 6:
                    MostrarEmpleadosPorFecha();
                    break;
                case 7:
                    AsignarCargoAEmpleado();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        static void CrearCategoria()
        {
            try
            {
                Console.WriteLine("Ingrese codigo");
                int.TryParse(Console.ReadLine(), out int codigo);
                Console.WriteLine("Ingrese descripción");
                string descripcion = Console.ReadLine();
                if (!string.IsNullOrEmpty(descripcion))
                {
                    Categoria categoria = new Categoria(codigo, descripcion);
                    miSistema.AltaCategoria(categoria);
                    Console.WriteLine("Alta  exitosa");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void MostrarCategorias()
        {
            Console.WriteLine("Lista de categorias");
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
            try
            {
                Console.WriteLine("Ingrese nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese documento");
                string documento = Console.ReadLine();
                Console.WriteLine("Lista de tipos de documentos");
                MostrarTiposDocumentos();
                Console.WriteLine("Ingrese nombre del tipo de documento");
                string tipo = Console.ReadLine();
                //Convierto el string recibido en un tipo de dato enumerado
                TipoDocumento tipoDocumento = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), tipo);
                Console.WriteLine("Ingrese fecha de ingreso");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaIngreso);
                Console.WriteLine("Ingrese fecha de antiguedad");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaAntiguedad);
                Console.WriteLine("Ingrese sueldo");
                double.TryParse(Console.ReadLine(), out double sueldo);
                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(documento)
                    && !string.IsNullOrEmpty(tipo) && fechaIngreso > DateTime.MinValue &&
                    fechaAntiguedad > DateTime.MinValue && sueldo>0)
                {
                    Mensual mensual = new Mensual(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad, sueldo);
                    miSistema.AltaEmpleadoMensual(mensual);
                    Console.WriteLine("Alta exitosa");
                }
                else
                {
                    Console.WriteLine("Datos incorrectos");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
       
        }
        static void CrearEmpleadoJornalero()
        {
            try
            {
                Console.WriteLine("Ingrese nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese documento");
                string documento = Console.ReadLine();
                Console.WriteLine("Lista de tipos de documentos");
                MostrarTiposDocumentos();
                Console.WriteLine("Ingrese nombre del tipo de documento");
                string tipo = Console.ReadLine();
                //Convierto el string recibido en un tipo de dato enumerado
                TipoDocumento tipoDocumento = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), tipo);
                Console.WriteLine("Ingrese fecha de ingreso");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaIngreso);
                Console.WriteLine("Ingrese fecha de antiguedad");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaAntiguedad);
                Console.WriteLine("Ingrese valor hora");
                double.TryParse(Console.ReadLine(), out double valorHora);
                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(documento)
                    && !string.IsNullOrEmpty(tipo) && fechaIngreso > DateTime.MinValue &&
                    fechaAntiguedad > DateTime.MinValue && valorHora > 0)
                {
                    Jornalero jornalero = new Jornalero(nombre, apellido, documento, tipoDocumento, fechaIngreso, fechaAntiguedad, valorHora);
                    miSistema.AltaEmpleadoJornalero(jornalero);
                    Console.WriteLine("Alta exitosa");
                }
                else
                {
                    Console.WriteLine("Datos incorrectos");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CrearCargo()
        {
            try
            {
                MostrarCategorias();
                Console.WriteLine("Ingrese el codigo de la categoría");
                int.TryParse(Console.ReadLine(), out int codCategoria);
                Console.WriteLine("Ingrese descripción del cargo");
                string descripcion = Console.ReadLine();
                if (!string.IsNullOrEmpty(descripcion) && codCategoria>0)
                {
                    Cargo cargo = new Cargo(descripcion);                    
                    miSistema.AltaCargo(cargo);
                    miSistema.AsignarCargoACategoria(codCategoria,cargo);
                    Console.WriteLine("El cargo se dio de alta");
               }
                else
                {
                    Console.WriteLine("La descripción es obligatoria y el codigo de categoria debe ser mayor a cero");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Permite mostrar la lista de tipos de documentos que es un enumerado
        /// </summary>
        static void MostrarTiposDocumentos()
        {
            string[] tiposDocumentos = Enum.GetNames(typeof(TipoDocumento));
            for(int i=0;tiposDocumentos.Length>i;i++)
            {
                Console.WriteLine(tiposDocumentos[i]);
            }
        }
        static void MostrarCargosDeCategoria()
        {
            try
            {
                
                MostrarCategorias();
                Console.WriteLine("Ingrese el codigo de la categoria");
                int.TryParse(Console.ReadLine(), out int codCategoria);
                if (codCategoria > 0)
                {
                    List<Cargo> cargosDeCategoria = miSistema.CargosDeCategoria(codCategoria);
                    if (cargosDeCategoria.Count > 0)
                    {
                        MostrarCargos(cargosDeCategoria);
                    }
                    else
                    {
                        Console.WriteLine("No existen cargos para la categoria indicada");
                    }

                }
                else
                {
                    Console.WriteLine("El codigo ingresado no es correcto");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MostrarCargos(List<Cargo> cargosCategoria)
        {
            Console.WriteLine("Lista de cargos");
            foreach(Cargo cargo in  cargosCategoria)
            {
                Console.WriteLine(cargo);
            }
        }
        static void MostrarEmpleadosPorFecha()
        {
            try
            {
                Console.WriteLine("Ingrese fecha desde");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde);
                Console.WriteLine("Ingrese fecha hasta");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta);
                if (fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue)
                {
                    List<Empleado> empleadosFiltradosPorFecha =
                        miSistema.EmpleadosFiltradoFechaIngreso(fechaDesde, fechaHasta);
                    if (empleadosFiltradosPorFecha.Count > 0)
                    {
                        MostrarEmpleados(empleadosFiltradosPorFecha);
                    }
                    else
                    {
                        Console.WriteLine("No existen empleados cuya fecha de ingreso este comprendida entre las " +
                            "fechas ingresadas");
                    }
                }
                else
                {
                    Console.WriteLine("Fechas incorrectas");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MostrarEmpleados(List<Empleado> empleadosPorFecha)
        {
            Console.WriteLine("Lista de empleados");
            foreach(Empleado empleado in empleadosPorFecha)
            {
                Console.WriteLine(empleado);
            }
        }
        static void AsignarCargoAEmpleado()
        {
            try
            {
                MostrarEmpleados(miSistema.Empleados);
                Console.WriteLine("Ingrese documento del empleado");
                string documento = Console.ReadLine();
                MostrarCargos(miSistema.Cargos);
                Console.WriteLine("Ingrese codigo de cargo");
                int.TryParse(Console.ReadLine(), out int codCargo);
                if (!string.IsNullOrEmpty(documento) && codCargo > 0)
                {
                    miSistema.AsignarCargoAEmpleado(codCargo, documento);
                    Console.WriteLine("El cargo se asigno correctamente");
                }
                else
                {
                    Console.WriteLine("El documento y/o codigo de cargo no son correctos");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
