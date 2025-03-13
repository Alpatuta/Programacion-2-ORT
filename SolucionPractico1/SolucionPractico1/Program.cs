namespace SolucionPractico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1();
            //Ejercicio2();
            Console.WriteLine("Hello, World!");
        }

      
        //Ejercicio 1
     
        static void Ejercicio1()
        {
            Console.WriteLine("Ingrese un número");
            int.TryParse(Console.ReadLine(), out int numeroIngresado);
            Random random = new Random();
            int numeroRandom = random.Next(1, 10);
            bool encontre = false;

            while (numeroIngresado != 0 && !encontre)
            {
                if(numeroIngresado == numeroRandom)
                {
                    Console.WriteLine("Los números son iguales");
                    encontre = true;
                }

                if (!encontre)
                {
                    Console.WriteLine("Ingrese un número");
                    int.TryParse(Console.ReadLine(), out numeroIngresado);
                }
            }

        }

        // Ejercicio 2

        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese un número");

        }
    }
}
