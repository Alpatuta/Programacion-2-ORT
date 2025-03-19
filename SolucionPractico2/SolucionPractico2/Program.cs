using Dominio;
namespace SolucionPractico2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1();
        }

        static void Ejercicio1() 
        {
            try
            {
                Auto auto = new Auto("Chevrolet", "Groove", true, "AAW3533", 2022);
                auto.Validar();
                Console.WriteLine(auto.ToString());

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
