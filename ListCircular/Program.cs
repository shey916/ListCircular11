// este archivo es mi program.cs
using ListCircular;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        List myList = new List();
        string input = string.Empty;
        string opcion = string.Empty;

        Console.WriteLine("--- Menu de lista circular ---");

        do
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Agregar un número a la lista (Add)");
            Console.WriteLine("2. Eliminar un número de la lista (Delete)");
            Console.WriteLine("3. Buscar un número en la lista (Search)");
            Console.WriteLine("4. Mostrar lista actual");
            Console.WriteLine("5. Contar elementos de la lista (Count)"); 
            Console.WriteLine("6. Salir del programa"); 
            Console.WriteLine("==============================================");

            Console.Write("Tu opción (1-6): ");
            opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    // --- Parte de Agregar (Add) ---
                    Console.WriteLine("--- METODO: AGREGAR ---");
                    Console.Write("Ingresa el número a AGREGAR: ");
                    input = Console.ReadLine();

                    if (input.ToLower() != "menu" && int.TryParse(input, out int dato))
                    {
                        if (myList.Exists(dato))
                        {
                            Console.WriteLine("El dato ya existe, no se puede agregar.");
                            continue;
                        }

                        Node n = new Node(dato);
                        myList.Add(n);

                        Console.WriteLine("\nDato Agregado");
                        Console.WriteLine("Estado actual de la lista:");
                        myList.Show();
                    }
                    else if (input.ToLower() != "menu")
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                    break;

                case "2":
                    // --- Parte de Eliminación (Delete) ---
                    Console.WriteLine("--- METODO: ELIMINAR ---");
                    Console.Write("Ingresa el número a ELIMINAR: ");
                    input = Console.ReadLine();

                    if (input.ToLower() != "menu" && int.TryParse(input, out int datoEliminar))
                    {
                        bool eliminadoExitosamente = myList.Delete(datoEliminar);

                        if (eliminadoExitosamente)
                        {
                            Console.WriteLine($"\n El número {datoEliminar} fue eliminado.");
                            Console.WriteLine("Estado actual de la lista:");
                            myList.Show();
                        }
                        else
                        {
                            Console.WriteLine($"\n El número {datoEliminar} no esta en la lista");
                            Console.WriteLine("Estado actual de la lista (sin cambios):");
                            myList.Show();
                        }
                    }
                    else if (input.ToLower() != "menu")
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                    break;

                case "3":
                    // --- Parte de Búsqueda (Search) ---
                    Console.WriteLine("--- METODO: BUSCAR ---");
                    Console.Write("Ingresa el número a BUSCAR: ");
                    input = Console.ReadLine();

                    if (input.ToLower() != "menu" && int.TryParse(input, out int datoBuscado))
                    {
                        Node resultado = myList.Search(datoBuscado);

                        if (resultado != null)
                        {
                            Console.WriteLine($"El número {datoBuscado} esta en la lista.");
                        }
                        else
                        {
                            Console.WriteLine($"El número {datoBuscado} no esta en la lista.");
                        }
                    }
                    else if (input.ToLower() != "menu")
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                    break;

                case "4":
                    // --- Mostrar Lista ---
                    Console.WriteLine("--- LISTA ACTUAL ---");
                    myList.Show();
                    break;

                case "5":
                    // ✅ NUEVO: Contar elementos
                    Console.WriteLine("--- METODO: COUNT ---");
                    int total = myList.Count();
                    Console.WriteLine($"La lista contiene {total} elemento(s).");
                    break;

                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, selecciona un número del 1 al 6.");
                    break;
            }

        } while (opcion != "6"); // 👈 Ahora se sale con el 6

        Console.WriteLine("\n--- Fin del programa. Lista final ---");
        myList.Show();
        Console.ReadKey();
    }
}