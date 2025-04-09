namespace Practico_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1();
            //Ejercicio2();
            Ejercicio3();
        }

        //Ejercicio 1

        static void Ejercicio1()
        {
            Console.WriteLine("Ingrese marca");
            string marca = Console.ReadLine();

            Console.WriteLine("Ingrese modelo");
            string modelo = Console.ReadLine();

            Console.WriteLine("Ingrese matricula");
            string matricula = Console.ReadLine();

            Console.WriteLine("Ingrese si el auto exonera impuestos. Valores validos Si/No");
            string exonera = Console.ReadLine();
            bool exoneraImpuestos = false;

            if (exonera == "Si")
            {
                exoneraImpuestos = true;
            }



            Console.WriteLine("Ingrese su año");
            int.TryParse(Console.ReadLine(), out int anio);

            try
            {
                Auto auto = new Auto(marca, modelo, matricula, exoneraImpuestos, anio);
                auto.Validar();
                Console.WriteLine(auto.DevolverDatos());

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Ejercicio 2

        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);

            Console.WriteLine("Ingrese el valor por hora");
            int.TryParse(Console.ReadLine(), out int valorHora);

            Console.WriteLine("Ingrese años de antiguedad");
            int.TryParse(Console.ReadLine(), out int aniosAntiguedad);

            Console.WriteLine("Ingrese cantidad de horas trabajadas");
            int.TryParse(Console.ReadLine(), out int horasTrabajadas);


            Empleado empleado = new Empleado(nombre, apellido, fechaNacimiento, valorHora, aniosAntiguedad, horasTrabajadas);
            empleado.Calcular();
            Console.WriteLine(empleado.DevolverDatos());

        }

        static void Ejercicio3()
        {
            Console.WriteLine("Ingrese id: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Ingrese la fecha: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaConsulta);

            Console.WriteLine("Ingrese el lugar: ");
            string lugar = Console.ReadLine();

            Console.WriteLine("Ingrese su cedula: ");
            string cedula = Console.ReadLine();

            Console.WriteLine("Ingrese si es urgente o no. Datos validos: Si/No");
            string urgente = Console.ReadLine();
            bool esUrgente = false;

            if(urgente == "Si")
            {
                esUrgente = true;
            }

            CitaMedica citaMedica = new CitaMedica(id, fechaConsulta, lugar, cedula, esUrgente);
            Console.WriteLine(citaMedica.MostrarDatos());
        }
    }
}
