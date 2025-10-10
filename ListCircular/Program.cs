using ListCircular;
using System;
using System.Threading;

internal class Program
{
    static void Main(string[] args)
    {
        List myList = new List();
        string input = string.Empty;
        string opcion = string.Empty;

        Console.WriteLine("--- Demo de Lista Enlazada Circular ---");

        do
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("        Selecciona una opción:");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Agregar un número (Add)");
            Console.WriteLine("2. Eliminar un número (Delete)");
            Console.WriteLine("3. Buscar un número (Search)");
            Console.WriteLine("4. Contar elementos (Count)"); 
            Console.WriteLine("5. Salir del programa");      
            Console.WriteLine("----------------------------------------------");

            Console.Write("Tu opción (1-5): ");
            opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    // --- Caso Agregar (Add) ---
                    Console.WriteLine("--- METODO: AGREGAR (ADD) ---");
                    Console.Write("Ingresa el número a AGREGAR (entero): ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int dato))
                    {
                        if (myList.Exists(dato))
                        {
                            Console.WriteLine($"El dato '{dato}' ya existe.");
                        }
                        else
                        {
                            Node n = new Node(dato);
                            myList.Add(n);
                            Console.WriteLine($"\nDato '{dato}' Agregado.");
                        }

                        // 🟢 MOSTRAR LISTA actual
                        Console.Write("Lista Actual: "); // Se usa Write en lugar de WriteLine
                        myList.ShowList();
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa un número entero válido.");
                    }
                    break;

                case "2":
                    
                    Console.WriteLine("--- METODO: ELIMINAR (DELETE) ---");
                    Console.Write("Ingresa el número a ELIMINAR : ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int datoEliminar))
                    {
                        bool eliminadoExitosamente = myList.Delete(datoEliminar);

                        if (eliminadoExitosamente)
                        {
                            Console.WriteLine($"\n El número {datoEliminar} fue ELIMINADO.");
                        }
                        else
                        {
                            Console.WriteLine($"\n El número {datoEliminar} no se encuentra en la lista.");
                        }
                       
                        Console.WriteLine("Estado actual de la lista:");
                        myList.ShowList();
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                    break;

                case "3":
                    
                    Console.WriteLine("--- METODO: BUSCAR (SEARCH) ---");
                    Console.Write("Ingresa el número a BUSCAR : ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int datoBuscado))
                    {
                        Node resultado = myList.Search(datoBuscado);

                        if (resultado != null)
                        {
                            Console.WriteLine($"\n El dato fue ENCONTRADO.  {resultado}");
                        }
                        else
                        {
                            Console.WriteLine($"\n El número {datoBuscado} no está en la lista.");
                        }
                        
                        Console.WriteLine("\nEstado actual de la lista:");
                        myList.ShowList();
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                    break;

                case "4": 
                    
                    Console.WriteLine("--- METODO: COUNT ---");
                    int total = myList.Count();
                    Console.WriteLine($"\n La lista contiene {total} elemento(s).");
                    Console.WriteLine("\nEstado actual de la lista:");
                    myList.ShowList();
                    break;

                case "5": 
                    Console.WriteLine("\nSaliendo del programa en 3 segundos...");
                    Thread.Sleep(3000);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona un número del 1 al 5.");
                    break;
            }

        } while (opcion != "5"); 

        Console.WriteLine("\n--- Fin del programa. Lista final ---");
        myList.ShowList();
        Console.ReadKey();
    }
}