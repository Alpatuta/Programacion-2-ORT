namespace SolucionPractico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1();
            //Ejercicio2();
            //Ejercicio3();
            //Ejercicio4();
            //Ejercicio5();
            //Ejercicio6();
            //Ejercicio7();
            Ejercicio8();
        
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

            while (primerNumero < segundoNumero && primerNumero != 0 && segundoNumero != 0 && valor != 0)
            {
                for(int i = primerNumero; i < segundoNumero; i++)
                {
                    if (i == valor)
                    {
                        Console.WriteLine("El valor esta comprendido entre los numeros");
                    }
                    
                }

                Console.WriteLine("Ingrese el primer numero");
                int.TryParse(Console.ReadLine(), out primerNumero);

                Console.WriteLine("Ingrese el segundo numero");
                int.TryParse(Console.ReadLine(), out segundoNumero);

                Console.WriteLine("Ingrese un valor");
                int.TryParse(Console.ReadLine(), out valor);
            }
        }

        // Ejercicio 5

        static void Ejercicio5()
        {
            Console.WriteLine("Ingrese un numero");
            int.TryParse(Console.ReadLine(), out int numero);

            int suma = 0;
            int numeroNuevo = 0;

            while (numero != 0)
            {
                suma = numeroNuevo + numero;
                numeroNuevo += numero;

                Console.WriteLine("Ingrese un numero");
                int.TryParse(Console.ReadLine(), out numero);
            }

            Console.WriteLine(suma);
        }

        //Ejercicio 6

        static void Ejercicio6()
        {
            Console.WriteLine("Ingrese una palabra");
            string palabra = Console.ReadLine();
            string palabraMin = palabra.ToLower();
            int contadorVocales = 0;
            
            for (int i = 0; i < palabraMin.Length; i++)
            {
                if (palabraMin[i] == 'a' || palabraMin[i] == 'e' || palabraMin[i] == 'i' || palabraMin[i] == 'o'|| palabraMin[i] == 'u')
                {
                    contadorVocales++;
                }
            }

            Console.WriteLine("Cantidad de vocales: " +  contadorVocales);
        }

        //Ejercicio 7

        static void Ejercicio7()
        {
            Console.WriteLine("Ingrese una palabra");
            string palabra = Console.ReadLine();
 

            Console.WriteLine($"Palabra dada vuelta: {DarVuelta(palabra)}");

        }

        static string DarVuelta(string palabraVuelta)
        {
            string nuevaPalabra = "";
            
            for (int i = palabraVuelta.Length - 1; i >= 0; i--)
            {
                nuevaPalabra += palabraVuelta[i];
            }

            return nuevaPalabra;
        }

        static void Ejercicio8()
        {
            Console.WriteLine("Ingrese una palabra");
            string palabra = Console.ReadLine();

            if(palabra.ToLower() == DarVuelta(palabra.ToLower()))
            {
                Console.WriteLine("La palabra es palíndroma");
            }
            else
            {
                Console.WriteLine("La palabra no es palínodroma");
            }
        }
    }
}
