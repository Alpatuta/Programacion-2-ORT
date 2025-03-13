namespace Clase1
{
    internal class Program
    {
        private static Persona[] _personas = new Persona[1];
        static void Main(string[] args)
        {
            AgregarPersona();
            MostrarNombrePersonas();
            bool existe = BuscarPersonaPorNombre("Federico");
            MostrarSiExistePersona("Federico", existe);
            Console.ReadKey();
        }
        static void AgregarPersona()
        {
            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido");
            string apellido = Console.ReadLine();
            if (nombre.Trim() != "" && apellido.Trim() != "")
            {
                Persona persona = new Persona(nombre, apellido);
                _personas[0] = persona;
                Console.WriteLine(nombre + "-" + apellido);
            }
        }

        static void MostrarNombrePersonas()
        {
            for(int i = 0; i < _personas.Length; i++)
            {
                Console.WriteLine(_personas[i].ObtenerNombre());
            }
        }

        static bool BuscarPersonaPorNombre(string nombrePersona)
        {
            int i = 0;
            bool existe = false;

            while(i < _personas.Length && !existe)
            {
                if (_personas[i].ObtenerNombre() == nombrePersona)
                {
                    existe = true;
                }
                i++;
            }

            return existe;
        }

        static void MostrarSiExistePersona(string nombrePersona, bool existe)
        {
            if (existe)
            {
                Console.WriteLine("La persona con nombre: " + nombrePersona + " existe");
            }
            else
            {
                Console.WriteLine("La persona con nombre " + nombrePersona + " no existe");
            }
        }

    }
}
