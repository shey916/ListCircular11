using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCircular
{
        internal class List
        {
            private Node head;

            // Constructor
            public List()
            {
                this.head = null;
            }

        public void Add(Node n)
            {
            Node h;
                // Caso 1: La lista está vacía
                if (head == null)
                {
                    head = n;
                    n.Next = head;
                    return;
                }

                // Caso 2: El nuevo nodo es menor que la cabeza (insertar al principio)
                if (n.Dato < head.Dato)
                {
                    // Encontrar el último nodo para actualizar su puntero
                    h = head;
                    while (h.Next != head)
                    {
                        h = h.Next;
                    }
                    
                    // Realizar la inserción
                    h.Next = n;
                    n.Next = head;
                    head = n;
                    return;
                }

                // Caso 3: Insertar en el medio o al final
                 h = head;
                while (h.Next != head)
                {
                    if (n.Dato < h.Next.Dato)
                    {
                        // Insertar en el medio
                        n.Next = h.Next;
                        h.Next = n;
                        return;
                    }
                    h = h.Next;
                }

                // Insertar al final (el bucle terminó, 'h' es el último nodo)
                h.Next = n;
                n.Next = head;
            }

        // --- Nuevo Método para Eliminar un Nodo ---
        public bool Delete(int datoEliminar)
        {
            Node h;
            // Caso 1: La lista está vacía
            if (head == null)
            {
                return false; // No hay nada que eliminar
            }

            // Caso 2: Eliminar la Cabeza (head)
            if (head.Dato == datoEliminar)
            {
                // Si solo hay un nodo
                if (head.Next == head)
                {
                    head = null; // La lista queda vacía
                    //return;
                }
                else
                {
                    // Si hay más de un nodo, primero encontramos el último nodo (hh)
                    h = head;
                    while (h.Next != head)
                    {
                        h = h.Next;
                    }

                    // Realizamos la eliminación del head:
                    // 1. El último nodo apunta al nuevo head (el segundo nodo)
                    h.Next = head.Next;
                    // 2. Movemos head al siguiente nodo (lo que era el segundo)
                    head = head.Next;
                }
                return true;
            }

            // Caso 3: Eliminar un nodo en el medio o al final
            h = head; // 'h' será la copia de head para recorrer

            // Recorremos la lista. Nos detenemos justo ANTES del nodo a eliminar
            // El bucle se detiene cuando h.Next llega al head, por eso se comprueba h.Next.Dato
            while (h.Next != head)
            {
                if (h.Next.Dato == datoEliminar)
                {
                    // Hemos encontrado el nodo a eliminar (es h.Next).

                    // Realizamos la eliminación:
                    // 1. El nodo actual (h) salta el siguiente nodo (h.Next)
                    h.Next = h.Next.Next;

                    // 2. El nodo que fue saltado (el eliminado) será recogido por el Garbage Collector.
                    return true; // La eliminación ha terminado
                }
                // Mover el puntero al siguiente nodo
                h = h.Next;
            }
            return false;
        }
        public Node Search(int dataToFind) // El dato buscado 
        {
            // 1. COMPROBACIÓN 
            if (head == null)
            {
                return null;
            }

            // 2. INICIALIZACIÓN
            Node n = head;

            // 3. INICIO DEL BUCLE
            do
            {
                // Comprobación de dato
                if (n.Dato == dataToFind)
                {
                    return n;
                }

                // Avance al siguiente nodo
                n = n.Next;

                // Condición de Parada: El bucle continúa mientras 'n' no regrese a 'head'.
            } while (n != head);

            // 4. Resultado Final (No encontrado)
            return null;
        }

        // Método para verificar si un dato ya existe en la lista
        public bool Exists(int dato)
        {
            if (head == null)
            {
                return false;
            }

            Node h = head;
            do
            {
                if (h.Dato == dato)
                {
                    return true; // El dato se encontró
                }
                h = h.Next;
            } while (h != head);

            return false; // El dato no se encontró
        }

        // Método para mostrar el contenido de la lista
        public void Show()
            {
                if (head == null)
                {
                    Console.WriteLine("La lista está vacía.");
                    return;
                }

                Node h = head;
                do
                {
                    Console.Write(h.Dato + " -> ");
                    h = h.Next;
                } while (h != head);

                Console.WriteLine("..."); // Indicando que es circular
            }

        public int Count()
        {
            // Caso: Lista vacía
            if (head == null)
            {
                return 0;
            }

            int count = 0;
            Node h = head;

            // Se utiliza un do-while para asegurar que se cuenta al menos el primer nodo (head)
            do
            {
                count++;
                h = h.Next;
            } while (h != head); // El bucle se detiene cuando volvemos a la cabeza

            return count;
        }
    }
}
