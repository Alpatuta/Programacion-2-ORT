namespace SolucionPractico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1();
            //Ejercicio2();
            Ejercicio3();
            //Ejercicio4();
        
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
            int.TryParse(Console.ReadLine(), out int numeroTabla);
            int multiplicador = 1;

            while(numeroTabla != 0)
            {
                for(int i  = 0; i < 9; i++)
                {
                    int resultado = numeroTabla * multiplicador;
                    Console.WriteLine(numeroTabla + " x " + multiplicador + " = " + resultado);
                    multiplicador++;
                }

                multiplicador = 1;
                Console.WriteLine("Ingrese un número");
                int.TryParse(Console.ReadLine(), out numeroTabla);
            }

        }

        // Ejercicio 3

        static void Ejercicio3()
        {
            Console.WriteLine("Ingrese el primer numero");
            int.TryParse(Console.ReadLine(), out int primerNumero);

            Console.WriteLine("Ingrese el segundo numero");
            int.TryParse(Console.ReadLine(), out int segundoNumero);

            while(primerNumero < segundoNumero && primerNumero != 0 && segundoNumero != 0)
            {
                for(int i = primerNumero; i < segundoNumero; i++)
                {
                    if(i % 2  == 0)
                    {
                        Console.WriteLine(i);
                        i++;
                    }
                }

                Console.WriteLine("Ingrese el primer numero");
                int.TryParse(Console.ReadLine(), out primerNumero);

                Console.WriteLine("Ingrese el segundo numero");
                int.TryParse(Console.ReadLine(), out segundoNumero);
            }
        }

        // Ejercicio 4

        static void Ejercicio4()
        {
            Console.WriteLine("Ingrese el primer numero");
            int.TryParse(Console.ReadLine(), out int primerNumero);

            Console.WriteLine("Ingrese el segundo numero");
            int.TryParse(Console.ReadLine(), out int segundoNumero);

            Console.WriteLine("Ingrese un valor");
            int.TryParse(Console.ReadLine(), out int valor);

            while (primerNumero < segundoNumero && primerNumero != 0)
            {
                for(int i =0; i < segundoNumero; i++)
                {
                    if (i == valor)
                    {
                        Console.WriteLine("El valor esta comprendido entre los numeros");
                    }

                    if(i != valor)
                    {
                        Console.WriteLine("El valor no esta comprendido entre los numeros");
                    }
                    
                }

                Console.WriteLine("Ingrese el primer numero");
                int.TryParse(Console.ReadLine(), out primerNumero);
            }
        }
    }
}
