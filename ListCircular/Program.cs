// este archivo es mi program.cs
using ListCircular;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        List myList = new List();
        string input = string.Empty;

        // Parte de inserción
        Console.WriteLine("--- Bienvenido a la Lista Circular Ordenada ---");
        Console.WriteLine("Escribe un número para agregarlo a la lista.");
        Console.WriteLine("Escribe 'salir' para terminar.");

        while (input.ToLower() != "salir" && input.ToLower() != "exit")
        {
            Console.Write("\nIngresa un número: ");
            input = Console.ReadLine();

            if (input.ToLower() == "salir" || input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int dato))
            {
                // Verifica si el dato ya existe antes de agregarlo
                if (myList.Exists(dato))
                {
                    Console.WriteLine("El dato ya existe. No se agregará a la lista.");
                    continue;
                }

                Node n = new Node(dato);
                myList.Add(n);

                Console.WriteLine("\nEstado actual de la lista:");
                myList.Show();
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número válido o 'salir'.");
            }
        }

        Console.WriteLine("\n--- Programa terminado. ---");
        Console.WriteLine("La lista final es:");
        myList.Show();

        // Parte de búsqueda
        Console.WriteLine("\n--- Ahora puedes buscar elementos en la lista. ---");
        Console.WriteLine("Escribe un número a buscar o 'salir' para finalizar.");

        input = string.Empty; // Reiniciamos la variable de entrada para el nuevo bucle
        while (input.ToLower() != "salir" && input.ToLower() != "exit")
        {
            Console.Write("\nIngresa el número a buscar: ");
            input = Console.ReadLine();

            if (input.ToLower() == "salir" || input.ToLower() == "exit")
            {
                break; // Sale del bucle de búsqueda
            }

            if (int.TryParse(input, out int datoBuscado))
            {
                // Llamada al método Search
                Node resultado = myList.Search(datoBuscado);

                if (resultado != null)
                {
                    Console.WriteLine($"¡Éxito! El número {datoBuscado} se encontró en la lista.");
                }
                else
                {
                    Console.WriteLine($"lo sentimos, el número {datoBuscado} no se encontró en la lista.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número válido o 'salir'.");
            }
        }

        // Parte de eliminación
        Console.WriteLine("\n--- Ahora puedes ELIMINAR elementos de la lista. ---");
        Console.WriteLine("Escribe un número a eliminar o 'salir' para finalizar.");

        input = string.Empty;
        while (input.ToLower() != "salir" && input.ToLower() != "exit")
        {
            Console.Write("\nIngresa el número a ELIMINAR: ");
            input = Console.ReadLine();

            if (input.ToLower() == "salir" || input.ToLower() == "exit")
            {
                break; // Sale del bucle de eliminación
            }

            if (int.TryParse(input, out int datoEliminar))
            {
                // ¡Llamada al método Delete() que implementaste!
                myList.Delete(datoEliminar);

                Console.WriteLine($"\nIntento de eliminación del número {datoEliminar} completado.");

                Console.WriteLine("Estado actual de la lista después de la eliminación:");
                    myList.Show(); // Muestra el estado actualizado
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número válido o 'salir'.");
            }
        }

        Console.WriteLine("\n--- Fin del programa. Lista final ---");
            myList.Show(); 
        Console.ReadKey();
    }
}
