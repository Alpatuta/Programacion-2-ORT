namespace Clase1
{
    internal class Program
    {
        private static Persona[] _personas = new Persona[1];
        static void Main(string[] args)
        {
            AgregarPersona();
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
    }
}
