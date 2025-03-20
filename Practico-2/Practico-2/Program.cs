namespace Practico_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1();
        }

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
    }
}
